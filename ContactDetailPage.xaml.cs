namespace FirstApp;

public partial class ContactDetailPage : ContentPage
{
    public event EventHandler<Models.Contact> ContactSaved;
    private Models.Contact contact;
    public ContactDetailPage(Models.Contact contact) {
        InitializeComponent();
        //create a copy so that the changes do not automatically save
        if (string.IsNullOrEmpty(contact.Name))
            contact.Name = "";
        if (string.IsNullOrEmpty(contact.Status))
            contact.Status = "";
        if (string.IsNullOrEmpty(contact.ImageUrl))
            contact.ImageUrl = "";

        this.contact = new Models.Contact();
        this.contact.Name = contact.Name;
        this.contact.Status = contact.Status;
        this.contact.ImageUrl = contact.ImageUrl;
		BindingContext = this.contact;
    }

    private async void SaveButtonClicked(object sender, EventArgs e) {
        ContactSaved?.Invoke(this, contact);
        await Navigation.PopAsync();
    }
}