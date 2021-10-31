namespace RestaurantOrder.Domain.Core.Entities
{
    public class NeededProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}
