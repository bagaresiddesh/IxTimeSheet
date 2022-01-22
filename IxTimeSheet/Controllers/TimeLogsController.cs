using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IxTimeSheet.DAL.Data;
using IxTimeSheet.DAL.Model;

namespace IxTimeSheet.Controllers
{
    public class TimeLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeLogs.ToListAsync());
        }

        // GET: TimeLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = await _context.TimeLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLog == null)
            {
                return NotFound();
            }

            return View(timeLog);
        }

        // GET: TimeLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Client,Project,Job,WorkItem,Date,Description,Hours,BillableStatus")] TimeLog timeLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeLog);
        }

        // GET: TimeLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = await _context.TimeLogs.FindAsync(id);
            if (timeLog == null)
            {
                return NotFound();
            }
            return View(timeLog);
        }

        // POST: TimeLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Client,Project,Job,WorkItem,Date,Description,Hours,BillableStatus")] TimeLog timeLog)
        {
            if (id != timeLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeLog);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = await _context.TimeLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLog == null)
            {
                return NotFound();
            }

            return View(timeLog);
        }

        // POST: TimeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeLog = await _context.TimeLogs.FindAsync(id);
            _context.TimeLogs.Remove(timeLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeLogExists(int id)
        {
            return _context.TimeLogs.Any(e => e.Id == id);
        }
    }
}
