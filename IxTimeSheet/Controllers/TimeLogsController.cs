using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace IxTimeSheet.Controllers
{   
    public class TimeLogsController : Controller
    {
        private readonly ITimeLog _timelog;

        public TimeLogsController(ITimeLog timelog)
        {
            _timelog= timelog;
        }

        // GET: TimeLogs
        public IActionResult Index()
        {
            var timelog=_timelog.GetAll().ToList();

            return View(timelog);
        }

        // GET: TimeLogs/Create
        public IActionResult Create()
        {
            var clients=_timelog.GetClients().ToList();
            var projects=_timelog.GetProjects().ToList();
            var jobs = _timelog.GetJobs().ToList();

            ViewBag.AllClients=clients;
            ViewBag.AllProjects=projects;
            ViewBag.AllJobs=jobs;

            return View();
        }

        // POST: TimeLogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Client,Project,Job,WorkItem,Date,Description,Hours,BillableStatus")] TimeLog timeLog)
        {
            var username = User.Identity.Name;
            
            if (ModelState.IsValid)
            {
                var clients = _timelog.GetClients().ToList();
                var projects = _timelog.GetProjects().ToList();
                var jobs = _timelog.GetJobs().ToList();

                int cid = Int32.Parse(timeLog.Client);
                int pid = Int32.Parse(timeLog.Project);
                int jid = Int32.Parse(timeLog.Job);

                timeLog.Client = clients.Where(x=>x.Id == cid).FirstOrDefault().Name;
                timeLog.Project = projects.Where(x=>x.Id==pid).FirstOrDefault().Name;
                timeLog.Job = jobs.Where(x=>x.Id==jid).FirstOrDefault().Name;

                timeLog.UserName = username;
                _timelog.Create(timeLog);
                return RedirectToAction("Index");
            }
            return View(timeLog);
        }

        // GET: TimeLogs/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = _timelog.GetById(id);
            if (timeLog == null)
            {
                return NotFound();
            }
            return View(timeLog);
        }

        // POST: TimeLogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,UserName,Client,Project,Job,WorkItem,Date,Description,Hours,BillableStatus")] TimeLog timeLog)
        {
            if (id != timeLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _timelog.Update(timeLog);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeLogExists(timeLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timeLog);
        }

        // GET: TimeLogs/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = _timelog.GetById(id);
            if (timeLog == null)
            {
                return NotFound();
            }

            return View(timeLog);
        }

        // POST: TimeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var timelog=_timelog.GetById(id);
            if(timelog == null)
            {
                return NotFound();
            }
            _timelog.Delete(id);

            return RedirectToAction("Index"); 
        }

        private bool TimeLogExists(int id)
        {
            return _timelog.Any(id);
        }

        public IActionResult GetProjectsByClientId(int clientId)
        {
            var projects=_timelog.GetProjects().ToList();

            projects = projects.Where(x => x.CId == clientId).ToList();

            var Result = projects.Select(m => new SelectListItem()
            {
                Value = m.Id.ToString(),
                Text = m.Name.ToString()
            });

            return new JsonResult(Result);
        }

        public IActionResult GetJobsByProjectId(int projectId)
        {
            var jobs = _timelog.GetJobs().ToList();

            jobs = jobs.Where(x => x.PId == projectId).ToList();

            var Result = jobs.Select(m => new SelectListItem()
            {
                Value = m.Id.ToString(),
                Text = m.Name.ToString()
            });

            return new JsonResult(Result);
        }
    }
}
