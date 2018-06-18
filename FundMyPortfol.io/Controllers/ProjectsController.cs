using FundMyPortfol.io.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FundMyPortfol.io.Controllers
{
    public class ProjectsController : Controller
    {
        #region Private Fields

        private readonly PortofolioContext _context;

        #endregion Private Fields

        #region Public Constructors

        public ProjectsController(PortofolioContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["ProjectCtrator"] = new SelectList(_context.User,"Id","Email");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedDate,Title,ProjectImage,Likes,PablishDate,ExpireDate,MoneyGoal,MoneyReach,Description,ProjectCtrator")] Project project)
        {
            if(ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectCtrator"] = new SelectList(_context.User,"Id","Email",project.ProjectCtrator);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.ProjectCtratorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.ProjectCtratorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if(project == null)
            {
                return NotFound();
            }
            ViewData["ProjectCtrator"] = new SelectList(_context.User,"Id","Email",project.ProjectCtrator);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,[Bind("Id,CreatedDate,Title,ProjectImage,Likes,PablishDate,ExpireDate,MoneyGoal,MoneyReach,Description,ProjectCtrator")] Project project)
        {
            if(id != project.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!ProjectExists(project.Id))
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
            ViewData["ProjectCtrator"] = new SelectList(_context.User,"Id","Email",project.ProjectCtrator);
            return View(project);
        }

        // GET: Projects
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var portofolioContext = _context.Project.Include(p => p.ProjectCtratorNavigation);
            return View(await portofolioContext.ToListAsync());
        }

        #endregion Public Methods

        #region Private Methods

        private bool ProjectExists(long id)
        {
            return _context.Project.Any(e => e.Id == id);
        }

        #endregion Private Methods
    }
}
