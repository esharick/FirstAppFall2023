namespace FirstApp;

public partial class MainPage : ContentPage
{
	int count = 8;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count+=1;
		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";
	}

	private void OnGoToClicked(object sender, EventArgs e) {
		var button = sender as Button;
		if (button == null)
			return;

		if (button.Text.Contains("Greet")) {
			var page = new GreetPage(count);
			page.NavigateAway += OnNavigatedAway;
			//page.NavigateAway += (obj, val) =>
			//{
			//	count = val;
			//          CounterBtn.Text = $"Clicked {count} times";
			//      };
			Navigation.PushAsync(page);
		}
		else if (button.Text.Contains("Collection")) {
			Navigation.PushAsync(new ContactListPage());
		}
		else{
			Navigation.PushAsync(new TabbedPageExample());
		}


	}

	private void OnNavigatedAway(object sender, int sliderValue) {
		count = sliderValue;
        CounterBtn.Text = $"Clicked {count} times";
	}
}

