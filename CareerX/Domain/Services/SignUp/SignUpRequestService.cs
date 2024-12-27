using AutoMapper;
using AutoMapper.Internal;
using Domain.Enums;
using Domain.Helpers;
using Domain.Models;
using Domain.Services.Email;
using Domain.Services.Jobseeker;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;

using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.SignUp.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Services.Jobseeker.Interface;
using Domain.Services.AuthUser.Interface;

namespace Domain.Services.SignUp
{
    public class SignUpRequestService : ISignUpRequestService
    {
        ISignUpRequestRepository _iSignUpRequestRepository;
        IAuthUserService _iAuthUserService;
        IEmailService emailService;


        IMapper _mapper;
        public SignUpRequestService(ISignUpRequestRepository SignUpRequestRepository, IMapper mapper, IEmailService _emailService,IAuthUserService authUserService)
        {
            _mapper = mapper;
            emailService = _emailService;
            _iSignUpRequestRepository = SignUpRequestRepository;
            _iAuthUserService = authUserService;
        }
        public async Task JobSeekerSignupInServiceCreation(JobSeekerSignUpRequestDTOs jobSeekerSignUpRequestDTOs)//(5) Execute JobSeekerSignUp Request implementation method of interface
                                                                                                                 //then map it to JobSeekerSignUpRequestDTOs
                                                                                                                 //then pass it to JobSeekerSignupInService
        {
            var jobSeekerSignUpRequest = _mapper.Map<SignUpRequest>(jobSeekerSignUpRequestDTOs);
            var sighnUpId = _iSignUpRequestRepository.AddSignupRequestInRepository(jobSeekerSignUpRequest);
            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "CareerX SignUp Verification";
            mailRequest.Body = GetHtmlContent(sighnUpId);
            mailRequest.ToEmail = jobSeekerSignUpRequest.Email;
            await emailService.SendEmailAsync(mailRequest);

        }
        private string GetHtmlContent(Guid signUpId)
        {
            string Response = "<div style=\"width:100%;background-color:lightblue;text-align:center;margin:10px;\">";
            Response += "<h1>Welcome to CareerX</h1>";
            Response += "<img src=\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9lPJ28B4QvMrZ3wE_qFUlKXnkF1zjoMS4kw&s\" />";

            Response += "<h2>Thanks for Joining CareerX</h2>";
            Response += "<h3>Please click on the link below to set your password</h3>";
            //"https://localhost:7183/api/v1/jobseeker/signup/CCADFB6A-7701-4AF8-A1A3-A0AFB0766CA1/Verify-Email' \
            Response += "https://localhost:7183/set-password?signupid=" + signUpId.ToString();
            Response += "<div><h1> Contact us : careerx@gmail.com</h1></div>";
            Response += "</div>";
            return Response;
        }
        public async Task<bool> VerifyJobseekerAsync(Guid jobSeekerSignupRequestId)
        {
            SignUpRequest signUpRequest = await _iSignUpRequestRepository.GetSignupRequestById(jobSeekerSignupRequestId);
            if (signUpRequest == null)
            {
                return false;
            }
            else
            {
                signUpRequest.Status = Enums.Status.VERIFIED;
                _iSignUpRequestRepository.UpdateSignupRequestInRepository(signUpRequest);
                return true;
            }
        }

        public async Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                SignUpRequest signupRequest = await _iSignUpRequestRepository.GetSignupRequestById(jobSeekerSignupRequestId);

                if (signupRequest == null)
                {
                    throw new ArgumentNullException(nameof(signupRequest), "SignUpRequest cannot be null Exception");

                }

                if (signupRequest.Status == Enums.Status.VERIFIED)
                {
                    Domain.Models.AuthUser authUser = _mapper.Map<Domain.Models.AuthUser>(signupRequest);
                    //authUser.UserName = signupRequest.UserName;
                    //    authUser.FirstName = signupRequest.FirstName;
                    //    authUser.LastName = signupRequest.LastName;
                    //    authUser.Phone = signupRequest.Phone;
                    //authUser.Email = signupRequest.Email;
                    authUser.Password = password;
                    authUser.Role = Enums.Role.JOB_SEEKER;
                    authUser.Status = Enums.Status.VERIFIED;
                    authUser = await _iAuthUserService.AddToAuthUser(authUser);
                    signupRequest.Status = Enums.Status.CREATED;
                    _iSignUpRequestRepository.UpdateSignupRequestInRepository(signupRequest);
                    Models.JobSeeker jobseeker = _mapper.Map<Models.JobSeeker>(authUser);
                    await _iSignUpRequestRepository.AddJobSeekerAsync(jobseeker);
                }


            }
            catch (Exception ex)
            {
                throw;

            }
        }


        //--------------------------------------- Company Admin ---------------------------------------


        public async Task CompanyAdminSignupInServiceCreation( CompanyAdminSignUpRequestDTOs CompanyAdminSignUpRequestDTOs)                                                                                                   //then pass it to JobSeekerSignupInService
        {
            var CompanyAdminSignUpRequest = _mapper.Map<SignUpRequest>(CompanyAdminSignUpRequestDTOs);
            var signUpId = _iSignUpRequestRepository.AddSignupRequestInRepository(CompanyAdminSignUpRequest);
            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "CareerX Company SignUp Verification";
            mailRequest.Body = GetHtmlContent(signUpId);
            mailRequest.ToEmail = CompanyAdminSignUpRequest.Email;
            await emailService.SendEmailAsync(mailRequest);
        }

        public async Task<bool> VerifyCompanyAdminAsync(Guid companyAdminSignupRequestId)
        {
            SignUpRequest signUpRequest = await _iSignUpRequestRepository.GetSignupRequestById(companyAdminSignupRequestId);
            if (signUpRequest == null)
            {
                return false;
            }
            else
            {
                signUpRequest.Status = Enums.Status.VERIFIED;
                _iSignUpRequestRepository.UpdateSignupRequestInRepository(signUpRequest);
                return true;
            }
        }

        public async Task CreateCompany(Guid companySignupRequestId, string password)
        {
            try
            {
                SignUpRequest signupRequest = await _iSignUpRequestRepository.GetSignupRequestById(companySignupRequestId);

                if (signupRequest == null)
                {
                    throw new ArgumentNullException(nameof(signupRequest), "SignUpRequest cannot be null Exception");

                }

                if (signupRequest.Status == Enums.Status.VERIFIED)
                {
                    Domain.Models.AuthUser authUser = _mapper.Map<Domain.Models.AuthUser>(signupRequest);
                    authUser.Password = password;
                    authUser.Role = Enums.Role.COMPANY_ADMIN;
                    authUser.Status = Enums.Status.VERIFIED;
                    authUser = await _iAuthUserService.AddToAuthUser(authUser);
                    signupRequest.Status = Enums.Status.CREATED;
                    _iSignUpRequestRepository.UpdateSignupRequestInRepository(signupRequest);
                    Models.CompanyAdmin companyAdmin = _mapper.Map<Models.CompanyAdmin>(authUser);
                    companyAdmin.Email = authUser.Email;
                    companyAdmin.Phone = authUser.Phone;
                    companyAdmin.AdminName = authUser.FirstName + " " + authUser.LastName;
                    await _iSignUpRequestRepository.AddCompanyAsync(companyAdmin);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
