namespace WebStore.Models.Order
{
    public class UserOrderViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public decimal TotalSum { get; set; }
    }
}
