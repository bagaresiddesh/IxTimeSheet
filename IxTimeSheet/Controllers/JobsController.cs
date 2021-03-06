using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace IxTimeSheet.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private readonly IJob _job;

        public JobsController(IJob job)
        {
            _job = job;
        }

        // GET: Jobs
        public IActionResult Index()
        {
            var job = _job.GetAll().ToList();

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            var projects = _job.GetProjects().ToList();
            ViewBag.Projects = projects;

            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,CreatedDate,UpdatedDate,PId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _job.Create(job);
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = _job.GetById(id);
            if (job == null)
            {
                return NotFound();
            }
            
            int pid = _job.GetById(id).PId;

            var projects = _job.GetProjects().ToList();
            var target = projects.Where(c => c.Id == pid).FirstOrDefault().Name;
            ViewBag.Project = target;

            return View(job);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,CreatedDate,UpdatedDate")] Job job)
        {
            int pid = _job.GetById(id).PId;

            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    job.PId = pid;
                    _job.Update(job);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(job);
        }


        // GET: Jobs/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = _job.GetById(id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var job = _job.GetById(id);
            if (job == null)
            {
                return NotFound();
            }
            _job.Delete(id);

            return RedirectToAction("Index");
        }

        private bool JobExists(int id)
        {
            return _job.Any(id);
        }
    }
}
