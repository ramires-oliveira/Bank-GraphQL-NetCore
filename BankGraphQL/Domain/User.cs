using System.ComponentModel.DataAnnotations.Schema;

namespace BankGraphQL.Domain
{
    public class User: Base
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
