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

        public async Task<Skill> AddSkillAsync(SkillsDtos skillDto)
        {
            try
            {
                var skill = _mapper.Map<Skill>(skillDto);
                skill.Id = Guid.NewGuid();
                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();
                return skill;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveSkillAsync(Guid id)
        {
            try
            {
                var skill = await _context.Skills.FindAsync(id);
                if (skill != null)
                {
                    _context.Skills.Remove(skill);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Location> AddLocation(LocationDtos location)
        {
            try
            {
                var locationEntity = _mapper.Map<Location>(location);
                await _context.Locations.AddAsync(locationEntity);
                await _context.SaveChangesAsync();
                return locationEntity;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveLocation(Guid locationId)
        {
            try
            {
                var location = await _context.Locations.FindAsync(locationId);
                if (location != null)
                {
                    _context.Locations.Remove(location);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Qualification> AddQualification(QualificationDtos qualification)
        {
            try
            {
                var qualificationEntity = _mapper.Map<Qualification>(qualification);
                await _context.Qualifications.AddAsync(qualificationEntity);
                await _context.SaveChangesAsync();
                return qualificationEntity;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveQualification(Guid qualificationId)
        {
            try
            {
                var qualification = await _context.Qualifications.FindAsync(qualificationId);
                if (qualification != null)
                {
                    _context.Qualifications.Remove(qualification);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Qualification>> GetAllQualifications()
        {
            return await _context.Qualifications.ToListAsync();
        }

        public async Task<Industry> AddIndustries(IndustryDtos industry)
        {
            try
            {
                var industryEntity = _mapper.Map<Industry>(industry);
                await _context.Industries.AddAsync(industryEntity);
                await _context.SaveChangesAsync();
                return industryEntity;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveIndustries(Guid id)
        {
            try
            {
                var industry = await _context.Industries.FindAsync(id);
                if (industry != null)
                {
                    _context.Industries.Remove(industry);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Industry>> GetIndustries()
        {
            return await _context.Industries.ToListAsync();
        }
    }
}
