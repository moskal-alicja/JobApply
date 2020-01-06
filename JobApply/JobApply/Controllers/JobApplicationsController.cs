﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApply.EntityFramework;
using JobApply.Models;

namespace JobApply.Controllers
{
    [Route("JobApplications")]
    public class JobApplicationsController : Controller
    {
        private readonly DataContext _context;

        public JobApplicationsController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets list of job applications.
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [Route("Index")]
        [Route("/")]
        [HttpGet]       
        public async Task<IActionResult> Index()
        {
            var jobApplications = await _context.JobApplications.ToListAsync();
            var applications = new List<JobApplicationViewModel>();
            foreach(var app in jobApplications)
            {
                var jobOffer = await _context.JobOffers.FindAsync(app.OfferId);
                applications.Add(new JobApplicationViewModel()
                {
                    OfferId = app.OfferId,
                    ApplicationId = app.Id,
                    JobTitle = jobOffer.JobTitle,
                    CompanyName = jobOffer.CompanyName,
                    Location = jobOffer.Location
                });
            }
            return View(applications);
        }

        /// <summary>
        /// Gets one job application and returns details view.
        /// </summary>
        /// <param name="id">Id of the Job Application Element</param>
        /// <returns></returns>
        /// 
        [Route("Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            JobApplicationViewModel model = jobApplication;
            var jobOffer = await _context.JobOffers.FirstOrDefaultAsync(m => m.Id == model.OfferId);
            if(jobOffer == null)
            {
                return NotFound();
            }
            model.JobTitle = jobOffer.JobTitle;
            model.CompanyName = jobOffer.CompanyName;
            model.Location = jobOffer.Location;           
            return View(model);
        }

        /// <summary>
        /// Gets new job apply form for chosen job offer. 
        /// </summary>
        /// <param name="id">Id of the Job Application Element</param>
        /// <returns></returns>
        [Route("ApplyForOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> ApplyForOffer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            JobApplicationViewModel model = new JobApplicationViewModel()
            {
                OfferId = id.Value,
                JobTitle = jobOffer.JobTitle,
                CompanyName = jobOffer.CompanyName,
                Location = jobOffer.Location
            };
            return View(model);
        }

        /// <summary>
        /// Saves new job application to database. 
        /// </summary>
        /// <remarks>Backend model validation.</remarks>
        /// <param name="application">Application form to save</param>
        /// <returns></returns>
        [Route("ApplyForOffer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyForOffer([Bind("OfferId,JobTitle,CompanyName,Location,FirstName,LastName,PhoneNumber,EmailAddress,ContactAgreement,CvUrl")] JobApplicationViewModel application)
        {
            if (ModelState.IsValid)
            {
                JobApplication jobApplication = application;
                jobApplication.Created = DateTime.Now;
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(application);
            }       
        }

        /// <summary>
        /// Deletes chosen job application.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Data deleted from database.</remarks>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.Id == id);
        }
    }
}
