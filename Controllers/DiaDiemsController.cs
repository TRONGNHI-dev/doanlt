using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelProject.Data;
using TravelProject.Models;

namespace TravelProject.Controllers
{
    public class DiaDiemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiaDiemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var diaDiems = _context.DiaDiems.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                diaDiems = diaDiems.Where(d =>
                    d.TenDiaDiem.Contains(searchString) ||
                    (d.DiaChi != null && d.DiaChi.Contains(searchString)) ||
                    (d.KhuVuc != null && d.KhuVuc.Contains(searchString)) ||
                    (d.LoaiHinh != null && d.LoaiHinh.Contains(searchString)));
            }

            ViewBag.SearchString = searchString;

            return View(await diaDiems
                .OrderByDescending(d => d.Id)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem = await _context.DiaDiems.FirstOrDefaultAsync(d => d.Id == id);
            if (diaDiem == null)
            {
                return NotFound();
            }

            return View(diaDiem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiaDiem diaDiem)
        {
            if (!ModelState.IsValid)
            {
                return View(diaDiem);
            }

            diaDiem.CreatedDate = DateTime.Now;
            _context.DiaDiems.Add(diaDiem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem = await _context.DiaDiems.FindAsync(id);
            if (diaDiem == null)
            {
                return NotFound();
            }

            return View(diaDiem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DiaDiem diaDiem)
        {
            if (id != diaDiem.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(diaDiem);
            }

            try
            {
                _context.DiaDiems.Update(diaDiem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaDiemExists(diaDiem.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem = await _context.DiaDiems.FirstOrDefaultAsync(d => d.Id == id);
            if (diaDiem == null)
            {
                return NotFound();
            }

            return View(diaDiem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaDiem = await _context.DiaDiems.FindAsync(id);
            if (diaDiem != null)
            {
                _context.DiaDiems.Remove(diaDiem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DiaDiemExists(int id)
        {
            return _context.DiaDiems.Any(d => d.Id == id);
        }
    }
}
