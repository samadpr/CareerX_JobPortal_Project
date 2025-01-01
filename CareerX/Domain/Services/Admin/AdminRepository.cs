using AutoMapper;
using Domain.Models;
using Domain.Services.Admin.DTOs;
using Domain.Services.Admin.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin
{
    public class AdminRepository:IAdminRepository
    {

        private readonly CareerxDbContext _context;
        IMapper _mapper;

        public AdminRepository(CareerxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<List<Domain.Models.JobSeeker>> GetJobSeekers()
        {
            return await _context.JobSeekers.ToListAsync();
        }
        public async Task<List<Domain.Models.CompanyAdmin>> GetCompanies()
        {
            return await _context.CompanyAdmins.ToListAsync();
        }
        public bool DeleteById(Guid id)
        {
            try
            {
                var jobSeeker = _context.JobSeekers.Find(id);
                if (jobSeeker != null)
                {
                    
                    var jobSeekerProfiles = _context.JobSeekerProfiles.Where(e => e.JobSeekerId == id).ToList();
                    if (jobSeekerProfiles.Any())
                    {
                         // for each profile check if it has same jobSeekerId and remove it,that is removeRange
                        _context.JobSeekerProfiles.RemoveRange(jobSeekerProfiles);
                    }

                   
                    _context.JobSeekers.Remove(jobSeeker);
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                 
                return false;
            }
        }
        public async Task<JobCategory> AddJobCategory(CategoryDtos jobCategory)
        {
            var category = _mapper.Map<JobCategory>(jobCategory);
            await _context.JobCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
