using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using ExpenseTracker;

namespace ExpenseTracker  // ← aquí
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            // … registra tus servicios, fuentes, estilos, etc.
            builder.UseMauiApp<App>();
            return builder.Build();
        }
    }
}

