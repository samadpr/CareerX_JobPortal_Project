using Domain.Models;
using Domain.Services.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager.Interface
{
    public interface IJobService
    {
        public void JobPostService(JobPostDtos jobPost) { }
        public void RemoveJobService(Guid jobIdToRemove) { }
        List<JobPost> ListPostedJobs(Guid companyId);



    }
}
