using Domain.Enums;
using Domain.Models;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp
{
    public class SignUpRequestRepository:ISignUpRequestRepository
    {
        protected readonly CareerxDbContext _context;
         
        public SignUpRequestRepository(CareerxDbContext context)
        {
            _context = context;
        }
       public  Guid AddSignupRequestInRepository(SignUpRequest siginUpRequest)
        {
            siginUpRequest.Status = (int)Status.PENDING;
            _context.SignUpRequests.AddAsync(siginUpRequest);
            _context.SaveChanges();
            return siginUpRequest.Id;
        }
        
    }
}
