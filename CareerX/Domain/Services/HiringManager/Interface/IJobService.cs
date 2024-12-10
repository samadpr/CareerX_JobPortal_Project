using Domain.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager.Interface
{
    public interface IJobService
    {
        public void PostJobService(JobPost job);
    }
}
