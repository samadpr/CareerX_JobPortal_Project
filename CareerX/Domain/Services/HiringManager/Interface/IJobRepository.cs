using Domain.Models;
using Domain.Services.Job.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager.Interface
{
    public interface IJobRepository
    {
        public void PostJob(JobPostDtos jobPost);
        public void RemoveJob(Guid jobIdToRemove);
        List<JobPost> ListPostedJobs(Guid companyId);
        
    }
}
