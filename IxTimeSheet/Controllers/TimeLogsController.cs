using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;

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
            return View();
        }

        // GET: TimeLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeLogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UserName,Client,Project,Job,WorkItem,Date,Description,Hours,BillableStatus")] TimeLog timeLog)
        {
            if (ModelState.IsValid)
            {
                _timelog.Create(timeLog);
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

            return View(); 
        }

        private bool TimeLogExists(int id)
        {
            return _timelog.Any(id);
        }
    }
}
