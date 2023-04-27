using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TavridaTest.Models;
using TavridaTest.Services;

namespace TavridaTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyBranchesController : ControllerBase
    {
        private readonly ICompanyDataAccess _companyDataAccess;

        public CompanyBranchesController(ICompanyDataAccess companyDataAccess)
        {
            _companyDataAccess = companyDataAccess;
        }

        [HttpGet]
        public IEnumerable<ListCompanyBranches> Get()
        {
            var data = DefineViewModelData(FillMethod.ByLINQ);
            //var data =  DefineViewModelData(FillMethod.ByTSQL);
            return data;
        }

        private enum FillMethod
        {
            ByLINQ,
            ByTSQL,
        };

        private List<ListCompanyBranches> DefineViewModelData(FillMethod fillMethod)
        {
            List<Company> companies = _companyDataAccess.GetCompanies().ToList();
            List<CompanyBranch> companyBranches = _companyDataAccess.GetCompanyBranches().ToList();

            List<ListCompanyBranches> listCompanyBranches = new List<ListCompanyBranches>();

            foreach (CompanyBranch currentCompanyBranch in companyBranches)
            {
                string? companyBranchName = "";
                string? company = "";
                string groupOfCompany = "";
                string relatedBranches = "";

                switch (fillMethod)
                {
                    case FillMethod.ByLINQ:
                        companyBranchName = currentCompanyBranch.Name;

                        Company targetCompany = companies.First(company => company.Id == currentCompanyBranch.CompanyId);
                        company = targetCompany.Name;
                        groupOfCompany = targetCompany.BinarySign ? "First" : "Second";

                        List<CompanyBranch> relatedBranchesList = companyBranches.Where(companyBranch => 
                            (companyBranch.CompanyId == targetCompany.Id) && (companyBranch != currentCompanyBranch)
                        ).ToList();

                        StringBuilder relatedBranchesBuilder = new StringBuilder();

                        CompanyBranch? last = null;
                        if (relatedBranchesList.Count > 0)
                        {
                            last = relatedBranchesList.Last();
                        }
                        foreach (var relatedBranch in relatedBranchesList)
                        {
                           
                            relatedBranchesBuilder.Append(relatedBranch.Name);
                            if (relatedBranch != last)
                            {
                                relatedBranchesBuilder.Append(", ");
                            }
                        }

                        relatedBranches = relatedBranchesBuilder.ToString();

                        break;
                    case FillMethod.ByTSQL:
                        listCompanyBranches = _companyDataAccess.GetListCompanyBranches().ToList();
                        break;
                    default:
                        break;
                }


                ListCompanyBranches lcb = new ListCompanyBranches(companyBranchName, company, groupOfCompany, relatedBranches);
                listCompanyBranches.Add(lcb);
            }

            return listCompanyBranches;
        }
    }
}
