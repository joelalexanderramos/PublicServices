namespace PublicServices.ViewModels
{
    using PublicServices.Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        #region Properties
        public List<GovService> GovServiceList
        {
            get;
            set;
        }
        #endregion

        #region ViewModels
        public GovServicesViewModel GovServices { get; set; }

        public GovServiceViewModel GovService { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.GovServices = new GovServicesViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            else
            {
                return instance;
            }
        }
        #endregion
    }
}
