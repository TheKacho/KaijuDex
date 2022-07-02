using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KaijuDex.Controllers
{
    public class MonsterController : Controller
    {
        private readonly Context _context;

        public MonsterController(Context context)
        {
            _context = context;
        }

        // GET: Monster
        public async Task<IActionResult> Index()
        {
              return _context.Monsters != null ? 
                          View(await _context.Monsters.ToListAsync()) :
                          Problem("Entity set 'Context.Monsters'  is null.");
        }

        // GET: Monster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Monsters == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // GET: Monster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Creator,BirthYear,ImageURL")] Monster monster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monster);
        }

        // GET: Monster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Monsters == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }
            return View(monster);
        }

        // POST: Monster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Creator,BirthYear,ImageURL")] Monster monster)
        {
            if (id != monster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterExists(monster.ID))
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
            return View(monster);
        }

        // GET: Monster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Monsters == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // POST: Monster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Monsters == null)
            {
                return Problem("Entity set 'Context.Monsters'  is null.");
            }
            var monster = await _context.Monsters.FindAsync(id);
            if (monster != null)
            {
                _context.Monsters.Remove(monster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterExists(int id)
        {
          return (_context.Monsters?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
