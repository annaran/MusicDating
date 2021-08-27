using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicDating.Models;
using MusicDating.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicDating.Models.ViewModels;
using MusicDating.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace MusicDating.Controllers
{
    public class UsersController : Controller
    {
        // Access to the database
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

   



        public async Task<IActionResult> Index(string selectedInstrument, string selectedGenre, int selectedLevelMin, int selectedLevelMax)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Selected instrument: " + selectedInstrument);
            Console.WriteLine("Selected genre: " + selectedGenre);


            // ---------- declaring variables in the scope -------------------
            int instrumentIdQuery = 0;
            int genreIdQuery = 0;
            IQueryable<ApplicationUser> users = null;



            // ---------- get all Instruments names in DB for select list ----------------
            IQueryable<string> instrumentQuery = from i in _context.Instruments
                                                 orderby i.Name
                                                 select i.Name;


            // ------------ find selected instrument id in DB --------------------
            if (!string.IsNullOrEmpty(selectedInstrument))
            {
                instrumentIdQuery = (from i in _context.Instruments
                                     where i.Name == selectedInstrument
                                     select i.InstrumentId).Single();
                Console.WriteLine("Selected instrumentId: " + instrumentIdQuery);
            }


            // --------- get all genre names in DB for select list -------------
            IQueryable<string> genreQuery = from g in _context.Genres
                                            orderby g.Name
                                            select g.Name;

            // ------------- find selected genre id in DB --------------
            if (!string.IsNullOrEmpty(selectedGenre))
            {
                genreIdQuery = (from g in _context.Genres
                                where g.Name == selectedGenre
                                select g.GenreId).Single();
                Console.WriteLine("Selected genreId: " + genreIdQuery);
            }


            // ------------- filter users and instruments with selected instrument levels ---------------
            var usersinstruments = from ui in _context.UserInstruments.Include(ui => ui.Instrument).Include(ui => ui.ApplicationUser)
                                       //  where ui.Level >= selectedLevelMin && ui.Level <= selectedLevelMax                  
                                   select ui;

            // ------------------ filter users and instruments with selected instrument levels ---------------
            var usersgenresdisplay = from d in _context.UserInstrumentGenres.Include(d => d.Genre).Include(d => d.UserInstrument)
                                     join i in _context.Instruments on d.InstrumentId equals i.InstrumentId
                                     join au in _context.ApplicationUsers on d.ApplicationUserId equals au.Id
                                     select d;



            // ------------------------ when user selects nothing ---------------------------------
            if (string.IsNullOrEmpty(selectedInstrument) == true && string.IsNullOrEmpty(selectedGenre) == true)
            {
                users = from d in _context.UserInstrumentGenres.Include(d => d.Genre).Include(d => d.UserInstrument)
                        join i in _context.Instruments on d.InstrumentId equals i.InstrumentId
                        join au in _context.ApplicationUsers on d.ApplicationUserId equals au.Id
                        where d.UserInstrument.Level >= selectedLevelMin && d.UserInstrument.Level <= selectedLevelMax
                        select au;
            }


            // -----------------  when user selects instrument and genre  --------------------------
            if (string.IsNullOrEmpty(selectedInstrument) == false && string.IsNullOrEmpty(selectedGenre) == false)
            {
                users = from d in _context.UserInstrumentGenres.Include(d => d.Genre).Include(d => d.UserInstrument)
                        join i in _context.Instruments on d.InstrumentId equals i.InstrumentId
                        join au in _context.ApplicationUsers on d.ApplicationUserId equals au.Id
                        where d.GenreId == genreIdQuery && d.InstrumentId == instrumentIdQuery && d.UserInstrument.Level >= selectedLevelMin && d.UserInstrument.Level <= selectedLevelMax
                        select au;
            }

            // --------------------- when user selects only instrument -----------------------------------------
            if ((string.IsNullOrEmpty(selectedInstrument) == false) && (string.IsNullOrEmpty(selectedGenre) == true))
            {

                users = from d in _context.UserInstrumentGenres.Include(d => d.Genre).Include(d => d.UserInstrument)
                        join i in _context.Instruments on d.InstrumentId equals i.InstrumentId
                        join au in _context.ApplicationUsers on d.ApplicationUserId equals au.Id
                        where d.InstrumentId == instrumentIdQuery && d.UserInstrument.Level >= selectedLevelMin && d.UserInstrument.Level <= selectedLevelMax
                        select au;
            }

            // ------------------- when user selects only genre ------------------------------------------------------
            if ((string.IsNullOrEmpty(selectedInstrument) == true) && (string.IsNullOrEmpty(selectedGenre) == false))
            {

                users = from d in _context.UserInstrumentGenres.Include(d => d.Genre).Include(d => d.UserInstrument).ThenInclude(d => d.Instrument)
                        join i in _context.Instruments on d.InstrumentId equals i.InstrumentId
                        join au in _context.ApplicationUsers on d.ApplicationUserId equals au.Id
                        where d.GenreId == genreIdQuery && d.UserInstrument.Level >= selectedLevelMin && d.UserInstrument.Level <= selectedLevelMax
                        select au;
            }


            var userInstrumentVm = new UserInstrumentVm
            {
                Instruments = new SelectList(await instrumentQuery.Distinct().ToListAsync()),
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Users = await users.Distinct().ToListAsync(),
                UserInstruments = await usersinstruments.ToListAsync(),
                UserInstrumentGenres = await usersgenresdisplay.ToListAsync()
            };


            // ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name");
            return View(userInstrumentVm);
        }



        public async Task<IActionResult> Details(string id)
        {

        

            if (id == null)
            {
                return NotFound();
            }


            //user
            var user = from u in _context.ApplicationUsers
            where u.Id == id
            select u;
             //   .FirstOrDefaultAsync(m => m.Id == id.ToString());

            if (user == null)
            {
                return NotFound();
            }


            //userinstrument
            var userinstruments = from ui in _context.UserInstruments
            .Include(d => d.UserInstrumentGenres).ThenInclude(d => d.Genre)
            .Include(d => d.Instrument)
             where ui.ApplicationUserId == id
             select ui;
            //.FirstOrDefaultAsync(m => m.ApplicationUserId == id.ToString());

            var ensembles = from e in _context.Ensembles
            where e.ApplicationUserId == id
            select e;
            //.FirstOrDefaultAsync(m => m.ApplicationUserId == id.ToString());
            if (ensembles == null)
            {
                return NotFound();
            }

            var posts = from p in _context.Posts
            where p.ApplicationUserId == id
            select p;
            //.FirstOrDefaultAsync(m => m.ApplicationUserId == id.ToString());
            if (posts == null)
            {
                return NotFound();
            }



            var userProfileVm = new UserProfileVm
            {     
                User = await user.ToListAsync(),
                UserInstruments = await userinstruments.ToListAsync(),
                UserPosts = await posts.ToListAsync()
            };

            return View(userProfileVm);
        }



        // GET: Sizes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }


            var model = new UserProfileEditVm{
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Postcode = user.Postcode,
                City = user.City,
                Description = user.Description

            };


            return View(model);
        }

        // POST: Sizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Postcode,City,Description")] UserProfileEditVm model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.Id ==  id);

 
            if (ModelState.IsValid)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Postcode = model.Postcode;
                user.City = model.City;
                user.Description = model.Description;

                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (user == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details",  new { id = id });
            }
            return View(model);
        }












    }





}