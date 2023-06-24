namespace CrudWebApi.Models
{
    public class PaymentHistory
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public long PaidAmount { get; set; }
        public DateTime PaidDate { get; set; }
    }
}
