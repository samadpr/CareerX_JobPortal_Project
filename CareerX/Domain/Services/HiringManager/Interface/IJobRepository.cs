using Domain.Services.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager.Interface
{
    public interface IJobRepository
    {
        public void PostJob(JobPostDtos jobPost) { }
    }
}
