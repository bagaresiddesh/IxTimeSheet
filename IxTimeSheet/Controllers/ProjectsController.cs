using Microsoft.AspNetCore.Mvc;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace IxTimeSheet.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProject _project;

        public ProjectsController(IProject project)
        {
            _project = project;
        }

        // GET: Projects
        public IActionResult Index()
        {
            return View();
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            var clients= _project.GetClients().ToList();
            ViewBag.Clients = clients;

            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CreatedDate,UpdatedDate,Client.Id,ddlClient")] Project project)
        {
            if (ModelState.IsValid)
            {
               // project.Client.Id = int.Parse(Request.Form["ddlClient"]);
                _project.Create(project);
                return View();
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _project.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var project = _project.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            _project.Delete(id);

            return View();
        }

        private bool ProjectExists(int id)
        {
            return _project.Any(id);
        }
    }
}
