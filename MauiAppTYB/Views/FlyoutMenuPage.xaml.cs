namespace MauiAppTYB.Views
{
    public class FlyoutMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }

    public partial class FlyoutMenuPage : ContentPage
    {
        public ListView ListView { get; set; }

        public FlyoutMenuPage()
        {
            InitializeComponent();
        }
    }
}