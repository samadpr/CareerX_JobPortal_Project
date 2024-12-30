using Domain.Services.HiringManager.Interface;
using Domain.Services.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager
{
    public class JobService :IJobService
    {
        private IJobRepository _repository;
        public JobService(IJobRepository repository)
        {
            _repository = repository;
        }
        public void JobPostService(JobPostDtos jobPost)
        {
            _repository.PostJob(jobPost);
        }
    } 
}
