using CommunityToolkit.Maui.Views;


namespace EncoreExpress.Pages
{
    public partial class SettingPage : ContentPage
    {
        private MediaElement mediaElement;

        public SettingPage(MediaElement mediaElement)
        {
            InitializeComponent();

            // Assign the passed mediaElement to the local variable
            this.mediaElement = mediaElement;

            // Populate playback speed options
            PopulateSpeedOptions();

            // Set initial values
            speedPicker.SelectedIndex = 2; // Default speed (1.0x)
            muteSwitch.IsToggled = false; // Default mute state (unmuted)

            // Event handlers
            speedPicker.SelectedIndexChanged += SpeedPicker_SelectedIndexChanged;
            muteSwitch.Toggled += MuteSwitch_Toggled;
            volumeSlider.ValueChanged += VolumeSlider_ValueChanged;
        }

        private void PopulateSpeedOptions()
        {
            speedPicker.Items.Add("0.5x");
            speedPicker.Items.Add("0.75x");
            speedPicker.Items.Add("1.0x");
            speedPicker.Items.Add("1.25x");
            speedPicker.Items.Add("1.5x");
            speedPicker.Items.Add("2.0x");
        }

        private void SpeedPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mediaElement != null && speedPicker.SelectedIndex >= 0)
            {
                double speed = GetSelectedSpeed();
                mediaElement.Speed = speed;
            }
        }

        private double GetSelectedSpeed()
        {
            string selectedSpeedText = speedPicker.SelectedItem.ToString().Replace("x", "");
            return double.Parse(selectedSpeedText);
        }

        private void MuteSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (mediaElement != null)
            {
                mediaElement.ShouldMute = e.Value;
                mediaElement.Volume = e.Value ? 0 : volumeSlider.Value;
            }
        }

        private void VolumeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (mediaElement != null)
            {
                mediaElement.Volume = e.NewValue;
            }
        }

        private async void GoBackToPlayerPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new PlayerPage();
        }
    }
}
