namespace Zaim.WebApi.Models
{
    public class CalculItem
    {
        public int Id { get; set; }
        public DateOnly DatePay { get; set; }
        public decimal Pay { get; set; }
        public decimal MainPay { get; set; }
        public decimal ProcentPay { get; set; }
        public decimal CreditBalance { get; set; }
    }
}
