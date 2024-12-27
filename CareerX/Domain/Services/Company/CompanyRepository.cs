using Domain.Models;
using Domain.Services.Company.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CareerxDbContext _context;
        public CompanyRepository(CareerxDbContext context)
        {
            _context = context;
        }


        public async Task<CompanyAdmin> GetCompanyByIdAsync(Guid companyId)
        {
            return await _context.CompanyAdmins.Where(c => c.Id == companyId).FirstOrDefaultAsync();
        }

        public async Task UpdateCompanyAsync(CompanyAdmin company)
        {
            _context.CompanyAdmins.Update(company);
            await _context.SaveChangesAsync();
        }
    }
}
