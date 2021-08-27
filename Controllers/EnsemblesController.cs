using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicDating.Data;
using MusicDating.Models.Entities;
using MusicDating.Models.ViewModels;

namespace MusicDating.Controllers
{
    public class EnsemblesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnsemblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ensembles
        public async Task<IActionResult> Index()
        {
            var ensembles = _context.Ensembles
                    .Include(e => e.Size)
                    .Include(e => e.PracticeFrequency)
                    .Include(e => e.EnsembleGenres)
                    .ThenInclude(e => e.Genre)
                    .AsNoTracking();




            return View(await ensembles.ToListAsync());
        }

        // GET: Ensembles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensemble = await _context.Ensembles
           .Include(e => e.Size)
           .Include(e => e.PracticeFrequency)
           .Include(e => e.EnsembleGenres).ThenInclude(e => e.Genre)
           .AsNoTracking()
           .FirstOrDefaultAsync(m => m.EnsembleId == id);

            if (ensemble == null)
            {
                return NotFound();
            }

            return View(ensemble);
        }

        // GET: Ensembles/Create
        public IActionResult Create()
        {
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Description");
            ViewData["PracticeFrequencyId"] = new SelectList(_context.PracticeFrequencies, "PracticeFrequencyId", "Description");
            var ensemble = new Ensemble();
            ensemble.EnsembleGenres = new List<EnsembleGenre>();
            PopulateAssignedGenreDataVm(ensemble);
            //  ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name");
            return View();
        }

        // POST: Ensembles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnsembleId,Name,Picture,Description,Homepage,Postcode,City,SizeId,PracticeFrequencyId,PlayRegular,PlayProject")] Ensemble ensemble, string[] selectedGenres)
        {
            if (selectedGenres != null)
            {
                ensemble.EnsembleGenres = new List<EnsembleGenre>();
                foreach (var genre in selectedGenres)
                {
                    var genreToAdd = new EnsembleGenre { EnsembleId = ensemble.EnsembleId, GenreId = int.Parse(genre) };
                    ensemble.EnsembleGenres.Add(genreToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(ensemble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //  ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Description", ensemble.SizeId);
            ViewData["PracticeFrequencyId"] = new SelectList(_context.PracticeFrequencies, "PracticeFrequencyId", "Description", ensemble.PracticeFrequencyId);

            PopulateAssignedGenreDataVm(ensemble);
            return View();
        }

        // GET: Ensembles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Description");
            ViewData["PracticeFrequencyId"] = new SelectList(_context.PracticeFrequencies, "PracticeFrequencyId", "Description");

            var ensemble = await _context.Ensembles
            .Include(e => e.EnsembleGenres).ThenInclude(e => e.Genre)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.EnsembleId == id);

            PopulateAssignedGenreDataVm(ensemble);


            if (ensemble == null)
            {
                return NotFound();
            }
            
            return View(ensemble);
        }

        // POST: Ensembles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //         public async Task<IActionResult> Edit(int id, [Bind("EnsembleId,Name,Picture,Description,Homepage,Postcode,City,SizeId,PracticeFrequencyId,PlayRegular,PlayProject")] Ensemble ensemble, string[] selectedGenres)

        public async Task<IActionResult> Edit(int? id, string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }


            var ensembleToUpdate = await _context.Ensembles
           .Include(e => e.EnsembleGenres)
           .ThenInclude(e => e.Genre)
           .FirstOrDefaultAsync(m => m.EnsembleId == id);

            // Console.WriteLine("ENSEMBLE TO UPDATE" +  ensemble.Description);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Description", ensembleToUpdate.SizeId);
            ViewData["PracticeFrequencyId"] = new SelectList(_context.PracticeFrequencies, "PracticeFrequencyId", "Description", ensembleToUpdate.PracticeFrequencyId);


            // if (ModelState.IsValid)
            if (await TryUpdateModelAsync<Ensemble>(
                                                     ensembleToUpdate,
                                                     "",
         e => e.Name, e => e.Picture, e => e.Description, e => e.Homepage, e => e.Postcode, e => e.City, e => e.SizeId, e => e.PracticeFrequencyId, e => e.PlayRegular, e => e.PlayProject))
            {
                UpdateEnsembleGenres(selectedGenres, ensembleToUpdate);
                try
                {
                    _context.Update(ensembleToUpdate);
                    //Console.WriteLine("*********Ensemble updated*********");
                    await _context.SaveChangesAsync();
                    //Console.WriteLine("*********Ensemble saved*********");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnsembleExists(ensembleToUpdate.EnsembleId))
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
            UpdateEnsembleGenres(selectedGenres, ensembleToUpdate);
            PopulateAssignedGenreDataVm(ensembleToUpdate);

            return View(ensembleToUpdate);
        }

        // GET: Ensembles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var ensemble = await _context.Ensembles
            .Include(e => e.Size)
            .Include(e => e.PracticeFrequency)
            .Include(e => e.EnsembleGenres).ThenInclude(e => e.Genre)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.EnsembleId == id);



            if (ensemble == null)
            {
                return NotFound();
            }

            return View(ensemble);
        }

        // POST: Ensembles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ensemble = await _context.Ensembles
                    .Include(e => e.EnsembleGenres)
                    .SingleAsync(i => i.EnsembleId == id);

            _context.Ensembles.Remove(ensemble);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnsembleExists(int id)
        {
            return _context.Ensembles.Any(e => e.EnsembleId == id);
        }

        private void PopulateAssignedGenreDataVm(Ensemble ensemble)
        {
            var allGenres = _context.Genres;
            var ensembleGenres = new HashSet<int>(ensemble.EnsembleGenres.Select(g => g.GenreId));
            var viewModel = new List<AssignedGenreDataVm>();
            foreach (var genre in allGenres)
            {
                viewModel.Add(new AssignedGenreDataVm
                {
                    GenreId = genre.GenreId,
                    Name = genre.Name,
                    Assigned = ensembleGenres.Contains(genre.GenreId)
                });
            }
            ViewData["Genres"] = viewModel;
        }



        private void UpdateEnsembleGenres(string[] selectedGenres, Ensemble ensembleToUpdate)
        {
            if (selectedGenres == null)
            {
                ensembleToUpdate.EnsembleGenres = new List<EnsembleGenre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var ensembleGenres = new HashSet<int>
                (ensembleToUpdate.EnsembleGenres.Select(g => g.Genre.GenreId));
            foreach (var genre in _context.Genres)
            {
                if (selectedGenresHS.Contains(genre.GenreId.ToString()))
                {
                    if (!ensembleGenres.Contains(genre.GenreId))
                    {
                        ensembleToUpdate.EnsembleGenres.Add(new EnsembleGenre { EnsembleId = ensembleToUpdate.EnsembleId, GenreId = genre.GenreId });
                    }
                }
                else
                {

                    if (ensembleGenres.Contains(genre.GenreId))
                    {
                        EnsembleGenre genreToRemove = ensembleToUpdate.EnsembleGenres.FirstOrDefault(e => e.GenreId == genre.GenreId);
                        _context.Remove(genreToRemove);
                    }
                }
            }
        }



    }
}
