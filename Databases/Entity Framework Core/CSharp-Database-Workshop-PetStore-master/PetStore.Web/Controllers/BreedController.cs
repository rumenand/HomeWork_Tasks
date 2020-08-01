using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetStore.ServiceModels.Breeds;
using PetStore.Services.Interfaces;
using PetStore.ViewModels.Breed;

namespace PetStore.Web.Controllers
{
    public class BreedController : Controller
    {
        private readonly IBreedService breedService;
        private readonly IMapper mapper;

        public BreedController(IBreedService breedService, IMapper mapper)
        {
            this.breedService = breedService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult All()
        {
            var allBreeds = breedService
                .GetAll()
                .ToList();

            ICollection<BreedViewModel> viewModels = this.mapper.Map<List<BreedViewModel>>(allBreeds);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(BreedViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            BreedServiceModel serviceModel = this.mapper.Map<BreedServiceModel>(model);

            this.breedService.AddBreed(serviceModel);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var result = this.breedService.RemoveById(id);

            if (!result)
            {
                return this.RedirectToAction("Error", "Home");
            }
            return this.RedirectToAction("All");
        }
    }
}