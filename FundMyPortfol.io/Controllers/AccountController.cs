using FundMyPortfol.io.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace FundMyPortfol.io.Models
{
    public class AccountController : Controller
    {
        #region Private Fields

        //public static PortofolioContext context;
        public readonly SignInManager<IdentityUser> _signInManager;

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly PortofolioContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        #endregion Private Fields

        #region Public Constructors

        //public LoginController(PortofolioContext context)
        //{
        //    _context = context;
        //}

        #endregion Public Constructors

        #region Public Methods

        // GET: Login/Create
        public IActionResult Create()
        {
            ViewData["UserDetails"] = new SelectList(_context.UserDetails,"Id","FirstName");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedDate,Email,Password,SeasonId,ProjectCounter,Followers,UserDetails")] User user)
        {
            if(ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            ViewData["UserDetails"] = new SelectList(_context.UserDetails,"Id","FirstName",user.UserDetails);
            return View(user);
        }

        // GET: Login
        public IActionResult Login()
        {
            //var portofolioContext = _context.User.Include(u => u.UserDetailsNavigation);
            //return View(await portofolioContext.ToListAsync());

            //if(_signInManager.IsSignedIn(user))
            ViewData["loginLabel"] = "Login";

            return View();
        }

        public virtual IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> SignUp([Bind("Email,Username,Password")]ViewUser user)
        {
            var newUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.Username,
            };
            //await _signInManager.SignInAsync(newUser,true);

            var result = await _userManager.CreateAsync(newUser,user.Password);

            logger.Info("Trying to authenticate user with Username :");

            if(result.Succeeded)
            {
                logger.Info("User Authentication successful :");
                //await _signInManager.SignInAsync(user,isPersistent: false);
                //_logger.LogInformation(3,"User created a new account with password.");
                //return RedirectToAction(nameof(HomeController.Index),"Home");
            }
            else
            {
                logger.Error("Authentication Failed for User :");
            }

            return Redirect("~/");
        }

        #endregion Public Methods

        #region Private Methods

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<IActionResult> Login([Bind("Username,Email,Password")]ViewUser user)
        {
            //var newUser = new ApplicationUser
            //{
            //    Email = user.Email,
            //    UserName = user.Username
            //};

            IdentityUser identityUser = await _userManager.FindByEmailAsync(user.Email);
            var result = _signInManager.CheckPasswordSignInAsync(identityUser,user.Password,false);

            if(result.Result.Succeeded)
            {
                logger.Info("User Authentication successful :");
                ViewData["loginLabel"] = "Welcome" + user.Username;
                return Redirect("~/");
                //await _signInManager.SignInAsync(user,isPersistent: false);
                //_logger.LogInformation(3,"User created a new account with password.");
                //return RedirectToAction(nameof(HomeController.Index),"Home");
            }
            else
            {
                logger.Error("Authentication Failed for User : " + user.Username);
                ViewData["loginLabel"] = "Login";
                return View();
            }

            //return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        //[AllowAnonymous]
        //public ActionResult Validate()
        //{
        //    return View();
        //}
        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        #endregion Private Methods
    }
}
