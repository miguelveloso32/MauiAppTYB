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

        // TODO: Add your authentication logic here
        // For example:
        // bool isAuthenticated = await AuthenticationService.ValidateCredentials(Username, Pin);

        // Temporary success message - replace with actual authentication
        await DisplayAlert("Successo", "Login feito com successo!", "OK");
    }

    private async void OnForgotPinTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ResetPinPage");
    }
}