using System;
using System.Collections.Generic;

namespace FundMyPortfol.io.Models
{
    public partial class Project
    {
        #region Public Constructors

        public Project()
        {
            Package = new HashSet<Package>();
        }

        #endregion Public Constructors

        #region Public Properties

        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public long Id { get; set; }
        public int Likes { get; set; }
        public decimal MoneyGoal { get; set; }
        public decimal MoneyReach { get; set; }
        public DateTime PablishDate { get; set; }
        public ICollection<Package> Package { get; set; }
        public long ProjectCtrator { get; set; }
        public User ProjectCtratorNavigation { get; set; }
        public byte[] ProjectImage { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}
