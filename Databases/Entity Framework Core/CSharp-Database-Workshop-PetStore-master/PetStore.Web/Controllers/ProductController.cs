using System.Collections;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;
using PetStore.ViewModels.Product;
using PetStore.ViewModels.Product.InputModels;
using PetStore.ViewModels.Product.OutputModels;

namespace PetStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult All()
        {
            var allProducts = productService
                .GetAll()
                .ToList();

            ICollection<ListAllProductsViewModel> viewModels = this.mapper.Map<List<ListAllProductsViewModel>>(allProducts);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            AddProductInputServiceModel serviceModel = this.mapper.Map<AddProductInputServiceModel>(model);

            this.productService.AddProduct(serviceModel);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            ProductDetailsServiceModel serviceModel = this.productService.GetById(id);

            ProductDetailsViewModel viewModel = this.mapper
                .Map<ProductDetailsViewModel>(serviceModel);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Search(string searchWord)
        {
            if (searchWord == null)
            {
                return this.RedirectToAction("All");
            }

            ICollection<ListAllProductsByNameServiceModel> serviceModels = this.productService.SearchByName(searchWord, false);

            ICollection<ListAllProductsViewModel> viewModels = this.mapper.Map<List<ListAllProductsViewModel>>(serviceModels);

            return this.View("All", viewModels);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ProductDetailsServiceModel serviceModel = this.productService.GetById(id);
            
            ProductEditViewModel viewModel = this.mapper
                .Map<ProductEditViewModel>(serviceModel);
            viewModel.Id = id;
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditProductInputServiceModel serviceModel = this.mapper.Map<EditProductInputServiceModel>(model);

            this.productService.EditProduct(model.Id,serviceModel);

            return this.RedirectToAction("All");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {            
            var result = this.productService.RemoveById(id);

            if (!result)
            {
                return this.RedirectToAction("Error", "Home");
            }
            return this.RedirectToAction("All");
        }
    }
}