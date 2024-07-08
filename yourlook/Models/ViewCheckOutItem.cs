namespace yourlook.Models
{
    public class ViewCheckOutItem
    {
        public string? TenKh { get; set; }
        public string? Sdt { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? DiaChi { get; set; }
        public decimal? TongTien { get; set; }
        public int? PaymentId { get; set; }
        public string? GhiChu { get; set; }
        public List<CheckOutItem>? CheckOutItems { get; set; }
    }
}
