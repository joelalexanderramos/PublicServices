namespace PublicServices.ViewModels
{
    using PublicServices.Models;

    public class GovServiceViewModel : BaseViewModel
    {
        #region Properties
        public GovService GovService
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public GovServiceViewModel(GovService govService)
        {
            this.GovService = govService;
        }
        #endregion
    }
}