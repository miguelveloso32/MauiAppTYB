namespace MauiAppTYB.Views;

public partial class UserInfoPage : ContentPage
{
	public UserInfoPage()
	{
		InitializeComponent();
        BindingContext = new UserInfoViewModel();
    }

    public class UserInfoViewModel
    {
        public string UserName { get; set; } = "username";
        public string Email { get; set; } = "user@example.com";
        public string FirstName { get; set; } = "First";
        public string LastName { get; set; } = "Last";
        public string Country { get; set; } = "Country";
        public string City { get; set; } = "City";
        public string Tenant { get; set; } = "Tenant";
        public string StoreTenant { get; set; } = "StoreTenant";
        public string Position { get; set; } = "Position";
        public string Departement { get; set; } = "Departement";
        public string PhoneNumber { get; set; } = "PhoneNumber";
        public string Role { get; set; } = "Role";
    }
}