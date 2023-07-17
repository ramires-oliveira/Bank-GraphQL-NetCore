using System.ComponentModel.DataAnnotations.Schema;

namespace BankGraphQL.Domain
{
    public class Base
    {
        public DateTime? DataCreate { get; set; } = DateTime.Now;
        public DateTime? DataModification { get; set; }
        public DateTime? DataDelete { get; set; }
        public bool? Active { get; set; } = true;
    }
}
