namespace MauiAppTYB.Views
{
    public partial class ResetPinPage : ContentPage
    {
        private string generatedPin;

        public ResetPinPage()
        {
            InitializeComponent();
            GenerateNewPin();
        }

        private void GenerateNewPin()
        {
            generatedPin = Random.Shared.Next(0, 10000).ToString("D4");
            NewPinLabel.Text = generatedPin;
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConfirmPinEntry.Text))
            {
                await DisplayAlert("Erro", "Por favor, insira o PIN de confirma��o", "OK");
                return;
            }

            if (ConfirmPinEntry.Text == generatedPin)
            {
                await DisplayAlert("Sucesso", "PIN atualizado com sucesso!", "OK");
                try
                {
                    await Shell.Current.GoToAsync("///LoginPage");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", "N�o foi poss�vel voltar � p�gina de login. Por favor, tente novamente.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Erro", "O PIN confirmado n�o corresponde ao novo PIN", "OK");
                ConfirmPinEntry.Text = string.Empty;
            }
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            try
            {
                // Navegar de volta para a p�gina inicial
                await Shell.Current.GoToAsync("///LoginPage");
            }
            catch (Exception ex)
            {
                // Log do erro e mostrar mensagem ao usu�rio
                await DisplayAlert("Erro", "N�o foi poss�vel voltar � p�gina de login. Por favor, tente novamente.", "OK");
            }
        }
    }
}