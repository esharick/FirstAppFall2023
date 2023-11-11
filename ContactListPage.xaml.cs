using FirstApp.Models;
using System.Collections.ObjectModel;

namespace FirstApp;


public partial class ContactListPage : ContentPage
{
	private ObservableCollection<Models.Contact> contacts, searchSubset;

	public ContactListPage()
	{
		InitializeComponent();
		InitializeContactList();
		searchSubset = new ObservableCollection<Models.Contact>();
		contactListView.ItemsSource = contacts;
	}

	private void InitializeContactList() {
		//could be replaced with a connection to a database or some other data file
		contacts = new ObservableCollection<Models.Contact>()
		{
			new Models.Contact() { Name="Alice", Status="Online", ImageUrl="dotnet_bot.png"},
            new Models.Contact() { Name="Bob", Status="Away", ImageUrl="dotnet_bot.png"},
			new Models.Contact() { Name="Chuck", Status="Offline", ImageUrl="dotnet_bot.png"},
            new Models.Contact() { Name="Dan", Status="Do not disturb", ImageUrl="dotnet_bot.png"},
			new Models.Contact() { Name="Eric", Status="Online", ImageUrl="dotnet_bot.png"},
        };
	}

    private void contactListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
		//var contact = e.SelectedItem as Models.Contact;
    }

    private void contactListView_ItemTapped(object sender, ItemTappedEventArgs e) {
		var contact = e.Item as Models.Contact;
		contact.Name = "Jeff";
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {
		//Empty Search bar
		if (string.IsNullOrEmpty(e.NewTextValue)) {
			contactListView.ItemsSource = contacts;
			return;
		}

		searchSubset.Clear();
		foreach(var contact in contacts) {
			if(contact.Name.Contains(e.NewTextValue) || contact.Status.Contains(e.NewTextValue)) {
				searchSubset.Add(contact);
			}
		}
		contactListView.ItemsSource = searchSubset;
    }

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e) {

    }
}