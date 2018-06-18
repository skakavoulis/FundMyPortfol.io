using System.ComponentModel.DataAnnotations;

namespace FundMyPortfol.io.ViewModels
{
    public partial class ViewUser
    {
        #region Public Constructors

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        #endregion Public Constructors
    }
}
