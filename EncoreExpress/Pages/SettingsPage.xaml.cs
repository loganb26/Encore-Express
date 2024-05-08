using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace EncoreExpress.Pages
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();

            // Other initialization code
        }

        private void LightModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                // Switch to light mode
                Application.Current.UserAppTheme = AppTheme.Light;
            }
            else
            {
                // Switch to dark mode
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
        }

        private void GoBackToPlayerPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new PlayerPage();
        }

        // Other methods
    }
}
