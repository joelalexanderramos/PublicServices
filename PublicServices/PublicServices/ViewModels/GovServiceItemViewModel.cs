namespace PublicServices.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using PublicServices.Models;
    using PublicServices.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class GovServiceItemViewModel : GovService
    {
        #region Commands
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectGovService);
            }
        }

        private async void SelectGovService()
        {
            MainViewModel.GetInstance().GovService = new GovServiceViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new GovServicePage());
        }
        #endregion
    }
}
