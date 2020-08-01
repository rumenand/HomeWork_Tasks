namespace PetStore.Common
{
    public static class ExceptionMessages
    {
        //Product
        public const string InvalidProductType = "Invalid product type provided!";
        public const string ProductNotFound = "Product with given id doesn't exist!";

        //Pet
        public const string InvalidPet = "Invalid pet data provided!";

        //Breed
        public const string InvalidBreed = "Invalid breed data provided!";

        //Orders
        public const string InvalidOrder = "Requested order is invalid";

        //Clients
        public const string InvalidClient = "Invalid client!";

        //Purchases
        public const string InvalidPurchase = "Invalid Purchase";
    }
}
