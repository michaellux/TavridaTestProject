using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavridaTest.Models
{
    [Table ("Companies")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool BinarySign { get; set; }
        public ICollection<CompanyBranch>? CompanyBranches { get; set; }
    }
}
