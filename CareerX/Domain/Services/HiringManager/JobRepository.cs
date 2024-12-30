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
    }
}
