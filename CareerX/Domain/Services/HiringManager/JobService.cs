using AutoMapper;
using Domain.Models;
using Domain.Services.HiringManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager
{
    internal class JobService:IJobService
    {
        private IJobRepository _jobRepository;
        public void PostJobService(JobPost job)
        {
            _jobRepository.PostJob(job);
        }
    }
}
