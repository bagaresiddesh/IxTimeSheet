using Microsoft.AspNetCore.Mvc;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace IxTimeSheet.Controllers
{
    [Authorize]
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
            var project = _project.GetAll().ToList();

            return View(project);
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
        public IActionResult Create([Bind("Id,Name,CreatedDate,UpdatedDate,CId")] Project project)
        {
            if (ModelState.IsValid)
            {               
                _project.Create(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public IActionResult Edit(int id)
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

            int cid = _project.GetById(id).CId;

            var clients = _project.GetClients().ToList();
            var target = clients.Where(c => c.Id == cid).FirstOrDefault().Name;
            ViewBag.Client = target;

            return View(project);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,CreatedDate,UpdatedDate")] Project project)
        {
            int cid = _project.GetById(id).CId;

            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    project.CId = cid;
                    _project.Update(project);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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

            return RedirectToAction("Index");

        }

        private bool ProjectExists(int id)
        {
            return _project.Any(id);
        }
    } 

}
