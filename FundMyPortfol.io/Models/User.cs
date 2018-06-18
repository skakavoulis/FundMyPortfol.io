using System;
using System.Collections.Generic;

namespace FundMyPortfol.io.Models
{
    public partial class User
    {
        #region Public Constructors

        public User()
        {
            BackerBuyPackage = new HashSet<BackerBuyPackage>();
            BackerFollowCreatorBackerNavigation = new HashSet<BackerFollowCreator>();
            BackerFollowCreatorProjectCreatorNavigation = new HashSet<BackerFollowCreator>();
            Project = new HashSet<Project>();
        }

        #endregion Public Constructors

        #region Public Properties

        public ICollection<BackerBuyPackage> BackerBuyPackage { get; set; }
        public ICollection<BackerFollowCreator> BackerFollowCreatorBackerNavigation { get; set; }
        public ICollection<BackerFollowCreator> BackerFollowCreatorProjectCreatorNavigation { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public int Followers { get; set; }
        public long Id { get; set; }
        public string Password { get; set; }
        public ICollection<Project> Project { get; set; }
        public int ProjectCounter { get; set; }
        public Guid? SeasonId { get; set; }
        public long UserDetails { get; set; }

        public UserDetails UserDetailsNavigation { get; set; }

        #endregion Public Properties
    }
}
