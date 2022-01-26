using Microsoft.AspNetCore.Mvc;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace IxTimeSheet.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClient _client;

        public ClientsController(IClient client)
        {
            _client = client;
        }

        // GET: Clients
        public IActionResult Index()
        {
            var clients=_client.GetAll().ToList();

            return View(clients);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CreatedDate,UpdatedDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                _client.Create(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _client.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,CreatedDate,UpdatedDate")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _client.Update(client);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _client.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = _client.GetById(id);
            if(client == null)
            {
                return NotFound();
            }
            _client.Delete(id);

            return RedirectToAction("Index");
        }

        private bool ClientExists(int id)
        {
            return _client.Any(id);
        }
    }
}
