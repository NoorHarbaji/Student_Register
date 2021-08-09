using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Register.Data;
using Student_Register.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Student_Register.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
      //  private readonly UserManager<ApplicationUser> _userManager;
      //  private readonly RoleManager<IdentityRole> _roleManager;
        //public StudentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        public StudentsController(ApplicationDbContext context)
        {
                _context = context;
           // _userManager = userManager;
           // _roleManager = roleManager;
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchString)
        {
           // await AddToAdminRole();
            var applicationDbContext = _context.Students.Include(c => c.Records);
            //if (User.IsInRole("Admin"))
           // {
                var applicationDbContext1 = from m in _context.Students
                                           select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    applicationDbContext1 = applicationDbContext1.Where(s => s.ID.ToString().Contains(searchString)
                    || s.FirstName.Contains(searchString));
                }
                return View(await applicationDbContext1.ToListAsync());
            //}
            //else
            //{
              //  var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
             //   var applicationDbContext1 = _context.Students.Where(studentl => studentl.PersonIdentity == userId).Include(r => r.Records);
             //   return View(await applicationDbContext1.ToListAsync());
           // }
            }

            // GET: Students/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var student = await _context.Students
                    .Include(@rec => @rec.Records)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (student == null)
                {
                    return NotFound();
                }

                return View(student);
            }

           // [Authorize(Roles = "Admin")]
            // GET: Students/Create
            public IActionResult Create()
            {
                ViewData["BatchID"] = new SelectList(_context.Batchs, "ID", "ID");
                return View();
            }

            // POST: Students/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Gender,DateOfBirth,Contact,Email,BatchID")] Student student)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["BatchID"] = new SelectList(_context.Batchs, "ID", "ID", student.BatchID);
                return View(student);
            }

            // GET: Students/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }

            // POST: Students/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Gender,DateOfBirth,Contact,Email")] Student student)
            {
                if (id != student.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(student);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StudentExists(student.ID))
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
                return View(student);
            }

            // GET: Students/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var student = await _context.Students
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (student == null)
                {
                    return NotFound();
                }

                return View(student);
            }

            // POST: Students/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var student = await _context.Students.FindAsync(id);
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool StudentExists(int id)
            {
                return _context.Students.Any(e => e.ID == id);
            }

       // private async Task<bool> AddToAdminRole()
        //{
          //  if (!User.IsInRole("Admin"))
           // {
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
              //  ApplicationUser user = _userManager.Users.Where(s => s.Id == userId).FirstOrDefault();
               // if (!await _roleManager.RoleExistsAsync("Admin"))
               // {
                //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
               // }
                //await _userManager.AddToRoleAsync(user, "Admin");
                //return true;
            //}
           // return false;
        //}
    }
    }
