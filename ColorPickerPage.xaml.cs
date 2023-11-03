namespace FirstApp;

public partial class ColorPickerPage : ContentPage
{
	public ColorPickerPage()
	{
		InitializeComponent();
	}

    private void SliderValueChanged(object sender, ValueChangedEventArgs e) {
		boxView.Color = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
		label.Text = String.Format("(R, G, B) = ({0:F0}, {1:F0}, {2:F0})",
			redSlider.Value, greenSlider.Value, blueSlider.Value);
	}
}