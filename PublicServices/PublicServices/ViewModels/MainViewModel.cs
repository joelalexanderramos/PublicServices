namespace PublicServices.ViewModels
{
    using PublicServices.Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        #region Properties
        public List<PublicService> PublicServiceList
        {
            get;
            set;
        }
        #endregion

        #region ViewModels
        //public LoginViewModel Login { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            //this.Login = new LoginViewModel();
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
