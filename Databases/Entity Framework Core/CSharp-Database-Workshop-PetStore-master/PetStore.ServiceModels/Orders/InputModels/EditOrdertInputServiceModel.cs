
using PetStore.Common;
using System.ComponentModel.DataAnnotations;

namespace PetStore.ServiceModels.Orders.InputModels
{
    public class EditOrdertInputServiceModel
    {
        [Required]
        public string Town { get; set; }

        [Required]
        [MinLength(GlobalConstants.AddressTextMinLength)]
        public string Address { get; set; }

        public string Notes { get; set; }
    }
}
