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


            // Em vez de usar Shell.Current, vamos definir diretamente no shell atual
            this.FlyoutBehavior = FlyoutBehavior.Disabled;

            LogoutCommand = new Command(async () => await OnLogoutClicked());
            BindingContext = this;
        }


        private async Task OnLogoutClicked()
        {
            bool answer = await DisplayAlert("Logout", "Tem certeza que deseja sair?", "Sim", "Não");
            if (answer)
            {
                // Aqui podemos usar this.FlyoutBehavior também
                this.FlyoutBehavior = FlyoutBehavior.Disabled;
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }



        // Método público para habilitar o menu após login bem-sucedido
        public void EnableFlyout()
        {
            this.FlyoutBehavior = FlyoutBehavior.Flyout;
        }



        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ResetPinPage), typeof(ResetPinPage));
            Routing.RegisterRoute(nameof(FlyoutMenuPage), typeof(FlyoutMenuPage));
            Routing.RegisterRoute(nameof(UserInfoPage), typeof(UserInfoPage));
            Routing.RegisterRoute(nameof(StorePage), typeof(StorePage));
            Routing.RegisterRoute(nameof(ActionPlanPage), typeof(ActionPlanPage));
            Routing.RegisterRoute(nameof(SupportPage), typeof(SupportPage));  
        }
    }
}