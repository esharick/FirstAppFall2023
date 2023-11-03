namespace FirstApp;

public partial class GreetPage : ContentPage
{
	public event EventHandler<int> NavigateAway;

	public GreetPage(int fontSize)
	{
		InitializeComponent();
		slider.Value = fontSize;
	}

    protected override bool OnBackButtonPressed() {
		Dispatcher.Dispatch(async () =>
		{
			var result = await DisplayAlert("Warning", "You are about to lose any unsaved changes", "Ok", "Cancel");
			if (result) {
				await Navigation.PopAsync();
			}				
		});
		return true;
    }


    private void ButtonClicked(object sender, EventArgs e) {
		var button = sender as Button;
		if(button != null) {
			if (button.BackgroundColor == Colors.LightBlue)
				button.BackgroundColor = Colors.Blue;
			else
				button.BackgroundColor = Colors.LightBlue;
		}
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e) {
		button.FontSize = e.NewValue;
    }

    private async void BackButtonClicked(object sender, EventArgs e) {
        var result = await DisplayAlert("Save data", "Do you want to save the slider value?", "Yes", "No");
        if (result) {
            NavigateAway?.Invoke(this, (int)slider.Value);
        }
        await Navigation.PopAsync();
    }
}