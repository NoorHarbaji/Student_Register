using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Register.Data;
using Student_Register.Models;
using Student_Register.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Register.Controllers
{
    public class BatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Batches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Batchs.ToListAsync());
        }

        // GET: Batches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batchs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        //Get: Batches/Courses/5
        public async Task<IActionResult> Courses(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var batch = await _context.Batchs.FirstOrDefaultAsync(m => m.ID == id);

            if (batch == null)
            {
                return NotFound();
            }
            var x = _context.Courses.Where(c => c.BatchId == id).ToList();
            var ac = new BatchCourse();
            ac.Batch = batch;
            ac.Courses = x;
            return View(ac);
        }

        // Get/Batche/students
        public async Task<IActionResult> Students(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batchs.FirstOrDefaultAsync(b => b.ID == id);
            if (batch == null)
            {
                return NotFound();
            }

            var s = _context.Students.Where(s => s.BatchID == id).ToList();
            var ast = new BatchStudents();
            ast.Students = s;
            ast.Batch = batch;
            return View(ast);
        }

        // GET: Batches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Bat,year")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batch);
        }

        // GET: Batches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batchs.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Bat,year")] Batch batch)
        {
            if (id != batch.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.ID))
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
            return View(batch);
        }

        // GET: Batches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batchs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batch = await _context.Batchs.FindAsync(id);
            _context.Batchs.Remove(batch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(int id)
        {
            return _context.Batchs.Any(e => e.ID == id);
        }
    }
}
