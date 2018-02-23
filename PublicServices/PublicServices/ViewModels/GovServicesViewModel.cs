namespace PublicServices.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class GovServicesViewModel : BaseViewModel
    {
        #region Services
        private APIService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<GovServiceItemViewModel> govServices;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<GovServiceItemViewModel> GovServices
        {
            get { return this.govServices; }
            set { SetValue(ref this.govServices, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public GovServicesViewModel()
        {
            this.apiService = new APIService();
            this.LoadGovermentServices();
        }
        #endregion

        #region Methods
        private async void LoadGovermentServices()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<GovService>(
                "http://map.gob.do",
                "/api",
                "/datos_abiertos/data=servicios_publicos&format=json");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            MainViewModel.GetInstance().GovServiceList = (List<GovService>)response.Result;
            this.GovServices = new ObservableCollection<GovServiceItemViewModel>(
                this.ToLandItemViewModel());
            this.IsRefreshing = false;
        }

        private IEnumerable<GovServiceItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().GovServiceList.Select(l => new GovServiceItemViewModel
            {
                Codigo = l.Codigo,
                Costo = l.Costo,
                Detalle = l.Detalle,
                FormaAcceso = l.FormaAcceso,
                Institucion = l.Institucion,
                Nombre = l.Nombre,
                Tiempo = l.Tiempo,
                UnidadResponsable = l.UnidadResponsable
            });
        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadGovermentServices);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.GovServices = new ObservableCollection<GovServiceItemViewModel>(
                    this.ToLandItemViewModel());
            }
            else
            {
                this.govServices = new ObservableCollection<GovServiceItemViewModel>(
                    this.ToLandItemViewModel().Where(
                        l => l.Nombre.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Institucion.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}