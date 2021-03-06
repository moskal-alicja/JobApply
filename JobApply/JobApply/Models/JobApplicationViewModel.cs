﻿using JobApply.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApply.Models
{
    [BindProperties]
    public class JobApplicationViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [CheckedAgreement]
        [Display(Name = "Contact Aggrement")]
        public bool ContactAgreement { get; set; }

        [Display(Name = "CV File")]
        public string CvUrl { get; set; }
        public int OfferId { get; set; }

        [Display(Name = "Sent")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Created { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public class CheckedAgreement : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                bool agreement = (bool)value;
                if (agreement)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(ErrorMessage ?? "This agreement field is required");
            }
        }

        public static implicit operator JobApplication(JobApplicationViewModel vm)
        {
            return new JobApplication
            {
                Id = vm.Id,
                OfferId = vm.OfferId,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                PhoneNumber = vm.PhoneNumber,
                EmailAddress = vm.EmailAddress,
                ContactAgreement = vm.ContactAgreement,
                CvUrl = vm.CvUrl,
                Created = vm.Created,
            };
        }

        public static implicit operator JobApplicationViewModel(JobApplication vm)
        {
            return new JobApplicationViewModel
            {
                Id = vm.Id,
                OfferId = vm.OfferId,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                PhoneNumber = vm.PhoneNumber,
                EmailAddress = vm.EmailAddress,
                ContactAgreement = vm.ContactAgreement,
                CvUrl = vm.CvUrl,
                Created = vm.Created,
            };
        }

    }
}
