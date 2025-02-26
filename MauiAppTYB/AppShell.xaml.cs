using System.Windows.Input;
using MauiAppTYB.Views;
namespace MauiAppTYB
{
    public partial class AppShell : Shell
    {

        public ICommand LogoutCommand { get; }

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

            LogoutCommand = new Command(async () => await OnLogoutClicked());
            BindingContext = this;
        }


        private async Task OnLogoutClicked()
        {
            bool answer = await DisplayAlert("Logout", "Tem certeza que deseja sair?", "Sim", "Não");
            if (answer)
            {
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }



        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ResetPinPage), typeof(ResetPinPage));
            Routing.RegisterRoute(nameof(FlyoutMenuPage), typeof(FlyoutMenuPage));
            Routing.RegisterRoute(nameof(UserInfoPage), typeof(UserInfoPage));
        }
    }
}