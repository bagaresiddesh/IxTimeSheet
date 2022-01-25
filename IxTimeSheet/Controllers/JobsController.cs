using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;

namespace IxTimeSheet.Controllers
{
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
            var job=_job.GetAll().ToList();

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
        public IActionResult Create([Bind("Id,Name,CreatedDate,UpdatedDate,PId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _job.Create(job);
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
            if(job==null)
            {
                return NotFound();
            }
            _job.Delete(id);
            return View();
        }

        private bool JobExists(int id)
        {
            return _job.Any(id);
        }
    }
}
