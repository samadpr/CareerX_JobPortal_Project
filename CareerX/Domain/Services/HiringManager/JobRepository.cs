using AutoMapper;
using Domain.Models;
using Domain.Services.HiringManager.Interface;
using Domain.Services.Job.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager
{
    public class JobRepository:IJobRepository
    {
        private CareerxDbContext _context;
        private IMapper _mapper;
        public JobRepository(CareerxDbContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }

        public void PostJob(JobPostDtos jobPost) {
            var mappedPost = _mapper.Map<JobPost>(jobPost);
            _context.JobPosts.Add(mappedPost);
            _context.SaveChanges();
        }
        public void RemoveJob(Guid jobIdToRemove) 
        {
            var selectedJob = _context.JobPosts.Find(jobIdToRemove);
            if (selectedJob != null)
            {
            _context.JobPosts.Remove(selectedJob);
            _context.SaveChanges();
            }
            else
            {
                //
            }
        }
        public List<JobPost> ListPostedJobs(Guid companyId)
        {
            //return using LINQ
            return _context.JobPosts.Where(x => x.CompanyId == companyId).ToList();
        }
        public List<JobService> ListApplicantsForJob(Guid JobId)
        {

        }
    }
}
