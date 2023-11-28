using FirstApp.Models;
using System.Collections.ObjectModel;

namespace FirstApp;


public partial class ContactListPage : ContentPage
{
	private ObservableCollection<Models.Contact> contacts, searchSubset;
	private ContactDatabase contactDB;
	public ContactListPage()
	{
		InitializeComponent();
		searchSubset = new ObservableCollection<Models.Contact>();
		contacts = new ObservableCollection<Models.Contact> { };
		contactListView.ItemsSource = contacts;
		contactDB = new ContactDatabase();
		LoadContactsFromDataBase();
	}
	private async void LoadContactsFromDataBase() {
		contacts.Clear();
		foreach (var contact in await contactDB.GetContactsAsync()) 
		{ 
			contacts.Add(contact);
		}
	}

	private async void ResetContactList() {
		//could be replaced with a connection to a database or some other data file
		contacts = new ObservableCollection<Models.Contact>()
		{
			new Models.Contact() { Name="Alice", Status="Online", ImageUrl="dotnet_bot.png"},
            new Models.Contact() { Name="Bob", Status="Away", ImageUrl="dotnet_bot.png"},
			new Models.Contact() { Name="Chuck", Status="Offline", ImageUrl="dotnet_bot.png"},
            new Models.Contact() { Name="Dan", Status="Do not disturb", ImageUrl="dotnet_bot.png"},
			new Models.Contact() { Name="Eric", Status="Online", ImageUrl="dotnet_bot.png"},
        };
		contactListView.ItemsSource = contacts;

        contactDB.ClearDatabase();
		foreach (var c in contacts) {
			await contactDB.SaveContactAsync(c);
		}
	}

    private void contactListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
		//var contact = e.SelectedItem as Models.Contact;
    }

    private void contactListView_ItemTapped(object sender, ItemTappedEventArgs e) {
		var contact = e.Item as Models.Contact;
        var detailPage = new ContactDetailPage(contact);
        detailPage.ContactSaved += (source, contactCopy) =>
        {
			contact.Name = contactCopy.Name;
			contact.Status = contactCopy.Status;
			contact.ImageUrl = contactCopy.ImageUrl;            
            contactDB.SaveContactAsync(contact);
        };
        Navigation.PushAsync(detailPage);
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

    private void ToolbarItem_Clicked(object sender, EventArgs e) {
		ResetContactList();
    }

    private void DeleteButtonClicked(object sender, EventArgs e) {
		var button = sender as Button;
		var contact = button.CommandParameter as Models.Contact;
		contacts.Remove(contact);
		contactDB.DeleteContactAsync(contact);
    }

    private void AddButtonClicked(object sender, EventArgs e) {
		var contact = new Models.Contact();
		var detailPage = new ContactDetailPage(contact);
        detailPage.ContactSaved += (source, contactCopy) =>
		{
			contacts.Add(contactCopy);
			contactDB.SaveContactAsync(contactCopy);
		};
        Navigation.PushAsync(detailPage);
    }



    private void SearchBar_SearchButtonPressed(object sender, EventArgs e) {

    }
}