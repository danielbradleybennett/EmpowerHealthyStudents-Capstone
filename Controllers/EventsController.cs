using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpowerHealthyStudents.Data;
using EmpowerHealthyStudents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.ComTypes;
using System.IO;

namespace EmpowerHealthyStudents.Controllers
{
    public class EventsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Events/Function is set up to see if general viewer or admin and redirect them to that view
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var Events = await _context.Event
                .ToListAsync();
            if(user != null)
            {
                if(user.IsAdmin == true)
                {
                    return RedirectToAction(nameof(AdminIndex));
                }

                return View(Events.OrderBy(e => e.Date));


            }
            return View(Events.OrderBy(e => e.Date));
        }

        // Admin view
        public async Task<ActionResult> AdminIndex()
        {
            var user = await GetCurrentUserAsync();
            var Events = await _context.Event
                .Where(e => e.UserId == user.Id)
                .ToListAsync();

            return View(Events.OrderBy(e => e.Date));
        }

        //// GET: Events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var Events = await _context.Event
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Events == null)
            {
                return NotFound();
            }

            return View(Events);
        }

        //// GET: Events/Create/Set it  up where only the Admin can create a new event
        public async Task<ActionResult> Create()
        {

            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                if (user.IsAdmin == true)
                {
                    return View();

                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Location,Date,UserId")] Event item)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the Event
                var user = await GetCurrentUserAsync();

                //builds up our new Event using the data submitted from the form, 
                //represented here as "BlogPos"
                var Events = new Event
                {
                    Id = item.Id,
                    Location = item.Location,
                    UserId = user.Id,
                    Date = item.Date

                };
                _context.Event.Add(Events);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(int id)
        {


            var user = await GetCurrentUserAsync();
            //var events = new Event();
            var events = await _context.Event.FirstOrDefaultAsync(e => e.Id == id);

            events.Location = events.Location;
            events.Date = events.Date;
            if (user != null)
            {

                if (user.IsAdmin == true)
                {
                    return View(events);
                }
                else
                {
                    
                    return RedirectToAction(nameof(Index));
                }

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }

            
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Event item)
        {
            try
            {
                var eventToUpdate = new Event()
                {
                    Id = item.Id,
                    Location = item.Location,
                    Date = item.Date

                };

                var user = await GetCurrentUserAsync();
                eventToUpdate.UserId = user.Id;

                _context.Event.Update(eventToUpdate);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var events = await _context.Event
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (events == null)
            {
                return NotFound();
            }

            if (user != null)
            {
                if (user.IsAdmin == true)
                {
                    return View(events);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
        

    }

        //// POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Event = await _context.Event.FindAsync(id);
            _context.Event.Remove(Event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}