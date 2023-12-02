namespace Bank
{
    public class Turn
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Hour { get; set; }
        public int CustomerId { get; set; }
        public int BankerId { get; set; }
    }
}
