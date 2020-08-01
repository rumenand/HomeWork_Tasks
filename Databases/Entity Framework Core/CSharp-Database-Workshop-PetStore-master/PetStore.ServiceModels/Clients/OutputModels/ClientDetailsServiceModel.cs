
using PetStore.Models;
using System.Collections.Generic;

namespace PetStore.ServiceModels.Clients.OutputModels
{
    public class ClientDetailsServiceModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public  ICollection<Pet> PetsBuyed { get; set; }
    }
}
