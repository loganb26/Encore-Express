using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace EncoreExpress.Pages
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            LoadThemeSetting();
        }

        private void LoadThemeSetting()
        {
            // Load the theme setting from preferences
            bool isLightMode = Preferences.Get("themePreference", true); // Default to light mode if no preference is set
            modeSwitch.IsToggled = isLightMode;
            Application.Current.UserAppTheme = isLightMode ? AppTheme.Light : AppTheme.Dark;
        }

        private void LightModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                // Switch to light mode
                Application.Current.UserAppTheme = AppTheme.Light;
                Preferences.Set("themePreference", true);
            }
            else
            {
                // Switch to dark mode
                Application.Current.UserAppTheme = AppTheme.Dark;
                Preferences.Set("themePreference", false);
            }
        }

        private void GoBackToPlayerPage(object sender, EventArgs e)
        {
            // Assuming you want to navigate back, check if Navigation is setup
            if (Navigation.NavigationStack.Count > 1)
            {
                Navigation.PopAsync();
            }
            else
            {
                App.Current.MainPage = new PlayerPage();
            }
        }
    }
}
