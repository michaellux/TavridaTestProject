using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TavridaTest.Models;

namespace TavridaTest.Services
{
    public interface ICompanyDataAccess
    {
        IEnumerable<Company> GetCompanies();
        IEnumerable<CompanyBranch> GetCompanyBranches();

        IEnumerable<ListCompanyBranches> GetListCompanyBranches();
    }

    public class CompanyDataAccess : ICompanyDataAccess
    {
        private readonly TavridaContext _context;

        public CompanyDataAccess(TavridaContext context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Company;
        }

        public IEnumerable<CompanyBranch> GetCompanyBranches()
        {
            return _context.CompanyBranch;
        }

        //https://timdeschryver.dev/blog/you-can-now-return-unmapped-types-from-raw-sql-select-statements-with-entity-framework-8
        public IEnumerable<ListCompanyBranches> GetListCompanyBranches()
        {
            var items = _context.Database.SqlQueryRaw<ListCompanyBranches>(
                @"
                  SELECT[Name] as Name,
                       (SELECT[Name]
                        FROM Companies

                        WHERE Companies.Id = CompanyId) as Company,
		                (SELECT[BinarySign]

                        FROM Companies

                        WHERE Companies.Id = CompanyId) as [Group]
                  FROM[TavridaTestProject].[dbo].[CompaniesBranches]"
            ).ToList();

            return items;
        }
    }
}
