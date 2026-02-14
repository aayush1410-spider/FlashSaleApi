namespace FlashSaleApi.Models
{
    public class ReserveRes
    {
        public string reservation_id { get; set; }
        public DateTime expires_at { get; set; }
        public string message { get; set; }
        public int? waitlist_position { get; set; }
    }
}
