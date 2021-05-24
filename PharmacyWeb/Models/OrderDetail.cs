namespace PharmacyWeb.Models
{
	public class OrderDetail
	{
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Medicine Medicine { get; set; }
        public Order Order { get; set; }
    }
}
