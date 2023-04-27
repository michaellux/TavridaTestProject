using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavridaTest.Models
{
    [Table("CompaniesBranches")]
    public class CompanyBranch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
