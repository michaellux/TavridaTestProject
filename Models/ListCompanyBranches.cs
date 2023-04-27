namespace TavridaTest.Models
{
    public class ListCompanyBranches
    {
        public string? Name { get; set; }
        public string? Company { get; set; }
        public string Group { get; set; }
        public string RelatedBranches { get; set; }

        public ListCompanyBranches(string? companyBranch, string? company, string groupOfcompany, string relatedBranches)
        {
            Name = companyBranch;
            Company = company;
            Group = groupOfcompany;
            RelatedBranches = relatedBranches;
        }
    }
}
