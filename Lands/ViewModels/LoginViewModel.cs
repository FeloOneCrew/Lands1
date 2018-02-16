namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
  

    // se Heredo la clase BaseViewModel para refrescar la app del celular
    class LoginViewModel : BaseViewModel
    {

        #region Atributes
        private string email;
        private string password;
        private bool isRunnig;
        private bool isEnable;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { this.SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { this.SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunnig; }
            set { this.SetValue(ref this.isRunnig, value); }
        }
        

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnable
        {
            get { return this.isEnable; }
            set { this.SetValue(ref this.isEnable, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;
            this.Email = "jzuluaga55@gmail.com";
            this.Password = "1234";

        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "You must enter an email",
                    "Accept");

                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "You must enter a password",
                    "Accept");

                return;
            }

            this.IsRunning = true;
            this.IsEnable = false;

            if (this.Email != "jzuluaga55@gmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Email or password wrong",
                    "Accept");
                this.Password = string.Empty;
                this.Email = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnable = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
