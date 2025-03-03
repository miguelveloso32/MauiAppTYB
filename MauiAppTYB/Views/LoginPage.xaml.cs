using System.Windows.Input;

namespace MauiAppTYB.Views;

public partial class LoginPage : ContentPage
{
    public string Username { get; set; }
    public string Pin { get; set; }
    public ICommand LoginCommand { get; set; }

    public LoginPage()
    {
        InitializeComponent();
        SetupBindings();
    }

    private void SetupBindings()
    {
        LoginCommand = new Command(async () => await OnLoginClicked());
        BindingContext = this;
    }

    private async Task OnLoginClicked()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Pin))
        {
            await DisplayAlert("Erro", "Por favor introduza Username e PIN", "OK");
            return;
        }

        // Verifica as credenciais baseado no tipo de usuário
        if (Username.ToLower() == "storemanager" && Pin == "1234")
        {
            if (Shell.Current is AppShell appShell)
            {
                appShell.EnableFlyout("Store Manager", "Pedro Cunha");
            }
            await Shell.Current.GoToAsync("//UserInfoPage");
        }
        else if (Username.ToLower() == "assistant" && Pin == "1235")
        {
            if (Shell.Current is AppShell appShell)
            {
                appShell.EnableFlyout("Assistant", "Ana Pinto");
            }
            await Shell.Current.GoToAsync("//UserInfoPage");
        }
        else if (Username.ToLower() == "inspector" && Pin == "1236")
        {
            if (Shell.Current is AppShell appShell)
            {
                appShell.EnableFlyout("Inspector", "Miguel Veloso");
            }
            await Shell.Current.GoToAsync("//UserInfoPage");
        }
        else
        {
            await DisplayAlert("Erro", "Credenciais inválidas", "OK");
        }
    }

    private async void OnForgotPinTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ResetPinPage");
    }
}