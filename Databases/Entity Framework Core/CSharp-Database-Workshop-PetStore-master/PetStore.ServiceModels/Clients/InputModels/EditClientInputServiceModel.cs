
using PetStore.Common;
using System.ComponentModel.DataAnnotations;

namespace PetStore.ServiceModels.Clients.InputModels
{
    public class EditClientInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstants.UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(GlobalConstants.EmailMinLength)]
        public string Email { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNameMinLength)]
        public string LastName { get; set; }
    }
}
