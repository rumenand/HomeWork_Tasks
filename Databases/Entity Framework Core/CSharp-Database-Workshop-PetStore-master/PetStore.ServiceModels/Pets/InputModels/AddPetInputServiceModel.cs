
using PetStore.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetStore.ServiceModels.Pets.InputModels
{
    public class AddPetInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstants.PetNameMinLength)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Range(GlobalConstants.PetMinAge, GlobalConstants.PetMaxAge)]
        public byte Age { get; set; }

        [Range(GlobalConstants.SellableMinPrice, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int BreedId { get; set; }
       
    }
}
