using Android.App;
using Android.Runtime;

namespace ExpenseTracker.Platforms.Android  // Coincide con tu RootNamespace
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership) 
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() 
            => MauiProgram.CreateMauiApp();
    }
}
