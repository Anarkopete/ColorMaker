using Microsoft.Maui.Controls;
using System;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            EstablecerColor(0, 0, 0);
        }

        // Método que actualiza el color según los sliders
        // Actua al recibir como evento mover los sliders, Llama a la funcion Establecer color
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            EstablecerColor(
                (int)RedSlider.Value,
                (int)GreenSlider.Value,
                (int)BlueSlider.Value
            );
        }

        // Método que establece el color en la caja de color y actualiza el HEX
        private void EstablecerColor(int r, int g, int b)
        {
            var color = Color.FromRgb(r, g, b);
            ColorBox.Color = color;
            HexLabel.Text = $"HEX Value: {ColorToHex(color)}";
        }

        // Botón para generar color aleatorio
        // Usando la funcion random asigna r,g,b tambien cambia los label
        private void RandomButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            RedSlider.Value = r;
            GreenSlider.Value = g;
            BlueSlider.Value = b;

            EstablecerColor(r, g, b);
        }

        // Función que convierte los colores a formato Hex
        // Color es un objeto con Red, Green, Blue, retorna formato Hex
        private string ColorToHex(Color color)
        {
            int r = (int)(color.Red * 255);
            int g = (int)(color.Green * 255);
            int b = (int)(color.Blue * 255);
            return $"#{r:X2}{g:X2}{b:X2}";
        }
        // Función para copiar al portapapeles
        // Recibe el evento de hacer click en el boton
        private async void Clipboard_Clicked(object sender, EventArgs e)
        {
            string colorHex = ColorToHex(ColorBox.Color);
            await Clipboard.Default.SetTextAsync(colorHex);
            await DisplayAlert("Copiado", $"Color {colorHex} copiado al portapapeles", "OK");
        }
    }
}
