namespace FundMyPortfol.io.Models
{
    public partial class PortofolioDataProvider
    {
        #region Private Fields

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion Private Fields

        #region Public Fields

        public static PortofolioContext context;

        #endregion Public Fields
    }
}
