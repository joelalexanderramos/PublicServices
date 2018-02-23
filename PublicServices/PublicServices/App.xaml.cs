namespace PublicServices
{
    using Xamarin.Forms;
    using Views;

    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new PublicServices.MainPage();
            this.MainPage = new NavigationPage(new GovServicesPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
