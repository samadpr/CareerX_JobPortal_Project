using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.HiringManager
{
    internal class JobRepository
    {
        private readonly CareerxDbContext _context;
        public JobRepository(CareerxDbContext context)
        {
            _context = context;
        }

        public void PostJob(JobPost job)
        {
            _context.JobPosts.Add(job);
            _context.SaveChanges();
        }
    }
}
