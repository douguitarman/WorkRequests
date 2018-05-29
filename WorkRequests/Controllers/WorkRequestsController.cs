using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkRequests.Models;
using WorkRequests.DAL;
using Microsoft.AspNet.Identity;
using WorkRequests.Extensions;

namespace WorkRequests.Controllers
{
    [Authorize]
    public class WorkRequestsController : Controller
    {
        // GET: WorkRequests
        public ActionResult Index()
        {
            WorkRequestViewModel model = new WorkRequestViewModel();
            DAL.WorkRequests wr = new DAL.WorkRequests();
            model.GetAllWorkRequests = wr.GetWorkRequests();

            return View(model);
        }

        // GET: WorkRequests/Details/5
        public ActionResult Details(int id)
        {
            WorkRequestViewModel model = new WorkRequestViewModel();
            DAL.WorkRequests wr = new DAL.WorkRequests();

            return View(wr.GetWorkRequest(id));
        }

        // GET: WorkRequests/Create
        public ActionResult Create()
        {
            WorkRequestViewModel model = new WorkRequestViewModel();
            model.Departments = DAL.WorkRequests.GetDepartments();
            model.Priorities = DAL.WorkRequests.GetPriorities();
            model.RequestTypes = DAL.WorkRequests.GetRequestTypes();

            return View(model);
        }

        // POST: WorkRequests/Create
        [HttpPost]
        public ActionResult Create(WorkRequestViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = User.Identity.GetFullName();
                    DAL.WorkRequests wr = new DAL.WorkRequests();
                    string result = wr.AddWorkRequest(model);

                    if (result == "-1")
                    {
                        TempData["Message"] = "Work request successfully created!";
                    }

                    ModelState.Clear();

                    return RedirectToAction("Index");
                }

                model.Departments = DAL.WorkRequests.GetDepartments();
                model.Priorities = DAL.WorkRequests.GetPriorities();
                model.RequestTypes = DAL.WorkRequests.GetRequestTypes();
                
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Error saving data");
                return View(model);
            }
        }

        // GET: WorkRequests/Edit/5
        public ActionResult Edit(int id)
        {
            WorkRequestViewModel model = new WorkRequestViewModel();
            DAL.WorkRequests wr = new DAL.WorkRequests();

            return View(wr.GetWorkRequest(id));
        }

        // POST: WorkRequests/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WorkRequestViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.LastUpdateBy = User.Identity.GetFullName();
                    model.WorkRequestId = id;
                    DAL.WorkRequests updateRequest = new DAL.WorkRequests();
                    string result = updateRequest.UpdateWorkRequest(model);

                    if (result == "-1")
                    {
                        TempData["Message"] = "Work request successfully updated!";
                    }

                    ModelState.Clear();

                    return RedirectToAction("Index");
                }

                model.Departments = DAL.WorkRequests.GetDepartments();
                model.Priorities = DAL.WorkRequests.GetPriorities();
                model.RequestTypes = DAL.WorkRequests.GetRequestTypes();
                model.Statuses = DAL.WorkRequests.GetStatuses();

                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Error saving data");
                return View(model);
            }
        }

        // GET: WorkRequests/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            WorkRequestViewModel model = new WorkRequestViewModel();
            DAL.WorkRequests wr = new DAL.WorkRequests();

            return View(wr.GetWorkRequest(id));
        }

        // POST: WorkRequests/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.WorkRequests deleteRequest = new DAL.WorkRequests();
                    string result = deleteRequest.DeleteWorkRequest(id);
                    
                    if (result == "-1")
                    {
                        TempData["Message"] = "Work request successfully deleted!";
                    }
                    
                    ModelState.Clear();

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
