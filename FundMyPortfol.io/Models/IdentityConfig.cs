using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace FundMyPortfol.io.Models
{
    //public class ApplicationUserManager : UserManager<ApplicationUser>
    //{

    #region Public Constructors

    public class ApplicationSignInManager
    {
        #region Private Fields

        private readonly IEmailSender emailSender;

        //private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        #endregion Private Fields

        #region Public Constructors

        public ApplicationSignInManager(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            //this.signInManager = signInManager;
            this.emailSender = emailSender;
        }

        #endregion Public Constructors
    }

    //public ApplicationUserManager(IUserStore<ApplicationUser> store)
    //    : base(store)
    //{
    //}
    //
    //#endregion Public Constructors
    //
    //#region Public Methods
    //
    //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,IOwinContext context)
    //{
    //    var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
    //    return manager;
    //}

    #endregion Public Constructors

    //}
}
