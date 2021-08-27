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
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(string selectedInstrument, string selectedGenre, int selectedLevelMin, int selectedLevelMax)
        {
                        // ---------- declaring variables in the scope -------------------
            //int instrumentIdQuery = 0;
            //int genreIdQuery = 0; 
            IQueryable<Post> posts = null;

            posts = from p in _context.Posts.Include(p => p.Instrument).Include(p => p.Ensemble).ThenInclude(p => p.Size).Include(p => p.PostGenres).ThenInclude(p => p.Genre)                       
                        where p.Level >= selectedLevelMin && p.Level <= selectedLevelMax 
                        select p;

            // filters for instrument, genre, level, location
            // button to create agent
            //var applicationDbContext = _context.Posts.Include(p => p.Ensemble).Include(p => p.Instrument);
            //ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name");
           // ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name");

          var searchPostVm = new SearchPostVm
            {
                Instruments = new SelectList(_context.Instruments, "InstrumentId", "Name"),
                Genres = new SelectList(_context.Genres, "GenreId", "Name"),
                Posts = await posts.Distinct().ToListAsync(),
                //UserInstruments = await usersinstruments.ToListAsync(),
                //PostGenres = await postgenres.ToListAsync()
            };


            return View(searchPostVm);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Ensemble)
                .Include(p => p.Instrument)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["EnsembleId"] = new SelectList(_context.Ensembles, "EnsembleId", "Name");
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name");
            //ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name");
            var post = new Post();
            post.PostGenres = new List<PostGenre>();

            PopulateAssignedGenreDataVm(post);
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Description,Level,InstrumentId,ApplicationUserId,EnsembleId,GenreId")] Post post, string[] selectedGenres)
        {

            if (selectedGenres != null)
            {
                post.PostGenres = new List<PostGenre>();
                foreach (var genre in selectedGenres)
                {
                    var genreToAdd = new PostGenre { PostId = post.PostId, GenreId = int.Parse(genre) };
                    post.PostGenres.Add(genreToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(post);              
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnsembleId"] = new SelectList(_context.Ensembles, "EnsembleId", "Name", post.EnsembleId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", post.InstrumentId);
            //ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name", post.PostGenres);
            PopulateAssignedGenreDataVm(post);
            return View();
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             var post = await _context.Posts
            .Include(e => e.PostGenres).ThenInclude(e => e.Genre)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.PostId == id);

            PopulateAssignedGenreDataVm(post);


            if (post == null)
            {
                return NotFound();
            }

            ViewData["EnsembleId"] = new SelectList(_context.Ensembles, "EnsembleId", "Name", post.EnsembleId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", post.InstrumentId);
            
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postToUpdate = await _context.Posts
           .Include(e => e.PostGenres)
           .ThenInclude(e => e.Genre)
           .FirstOrDefaultAsync(m => m.PostId == id);


             if (await TryUpdateModelAsync<Post>(
                                                     postToUpdate,
                                                     "",
         e => e.Title, e => e.Description, e => e.Level, e => e.InstrumentId, e => e.ApplicationUserId, e => e.EnsembleId))

            {
                 UpdatePostGenres(selectedGenres, postToUpdate);
                try
                {
                    _context.Update(postToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(postToUpdate.PostId))
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
            ViewData["EnsembleId"] = new SelectList(_context.Ensembles, "EnsembleId", "Name", postToUpdate.EnsembleId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", postToUpdate.InstrumentId);
            UpdatePostGenres(selectedGenres, postToUpdate);
            PopulateAssignedGenreDataVm(postToUpdate);
            return View(postToUpdate);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Ensemble)
                .Include(p => p.Instrument)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }

        private void PopulateAssignedGenreDataVm(Post post)
        {
            var allGenres = _context.Genres;
            var postGenres = new HashSet<int>(post.PostGenres.Select(g => g.GenreId));
            var viewModel = new List<AssignedGenreDataVm>();
            foreach (var genre in allGenres)
            {
                viewModel.Add(new AssignedGenreDataVm
                {
                    GenreId = genre.GenreId,
                    Name = genre.Name,
                    Assigned = postGenres.Contains(genre.GenreId)
                });
            }
            ViewData["Genres"] = viewModel;
        }


        private void UpdatePostGenres(string[] selectedGenres, Post postToUpdate)
        {
            if (selectedGenres == null)
            {
                postToUpdate.PostGenres = new List<PostGenre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var postGenres = new HashSet<int>
                (postToUpdate.PostGenres.Select(g => g.Genre.GenreId));
            foreach (var genre in _context.Genres)
            {
                if (selectedGenresHS.Contains(genre.GenreId.ToString()))
                {
                    if (!postGenres.Contains(genre.GenreId))
                    {
                        postToUpdate.PostGenres.Add(new PostGenre { PostId = postToUpdate.PostId, GenreId = genre.GenreId });
                    }
                }
                else
                {

                    if (postGenres.Contains(genre.GenreId))
                    {
                        PostGenre genreToRemove = postToUpdate.PostGenres.FirstOrDefault(e => e.GenreId == genre.GenreId);
                        _context.Remove(genreToRemove);
                    }
                }
            }
        }


    }
}
