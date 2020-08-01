
using PetStore.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetStore.ServiceModels.Purchases.InputModels
{
    public class ClientProductInputServiseModel
    {
        [Required]
        public string ClientId { get; set; }      

        [Required]
        public string ProductId { get; set; }

        [Range(GlobalConstants.ClientProductMinQuantity, Int32.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public string OrderId { get; set; }
    }
}
