namespace FirstApp;

public partial class WordlePage : ContentPage {
	public WordlePage() {
		InitializeComponent();
		SetupGuessGrid();
		SetupKeyboardGrid();
	}

	private void SetupKeyboardGrid() {
		var keys1 = new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };
		var keys2 = new string[] { "A", "S", "D", "F", "G", "H", "J", "K", "L" };
		var keys3 = new string[] { "Ent", "Z", "X", "C", "V", "B", "N", "M", "Del" };

		var col = 0;
		foreach (var key in keys1) {
			var button = new Button
			{
				Text = key,
				FontSize = 20,
				BackgroundColor = Colors.DarkGray,
				BorderColor = Colors.White,
			};
			keyboardRow1.Add(button, col++, 0);
		}
		col = 0;
		foreach (var key in keys2) {
			var button = new Button
			{
				Text = key,
				FontSize = 20,
				BackgroundColor = Colors.DarkGray,
				BorderColor = Colors.White,
			};
			keyboardRow2.Add(button, col++, 1);
		}
		col = 0;
		foreach (var key in keys3) {
			var button = new Button
			{
				Text = key,
				FontSize = 20,
				BackgroundColor = Colors.DarkGray,
				BorderColor = Colors.White,
			};
			keyboardRow3.Add(button, col++, 2);
		}
	}

	private void SetupGuessGrid() {
		for (var col = 0; col < 5; col++)
			for (var row = 1; row < 7; row++) {

				var label = new Label
				{
					FontSize = 16,
					Text = "",
					TextColor = Colors.White,
					HorizontalOptions = LayoutOptions.Center
				};

				var border = new Border
				{
					Stroke = Colors.White,
					Content = label,
					Padding = new Thickness(5)
				};
				guessGrid.Add(border, col, row);
			}
		//guessGrid.Add(new Label{ Text="A"}, 0, 1);
	}

    private void ToolbarItemClicked(object sender, EventArgs e) {
		var item = sender as ToolbarItem;
		DisplayAlert("Toolbar Item Clicked", item.Text, "Ok");
    }
}