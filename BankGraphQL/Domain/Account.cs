namespace BankGraphQL.Domain
{
    public class Account: Base
    {
        public Guid? Id { get; set; }
        public string? Number { get; set; }
        public decimal Value { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

    }
}
