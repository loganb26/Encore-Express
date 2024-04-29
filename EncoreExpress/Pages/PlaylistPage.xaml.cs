using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace EncoreExpress.Pages
{
    public partial class PlaylistPage : ContentPage
    {
        public ObservableCollection<Song> Songs { get; set; }

        public PlaylistPage()
        {
            InitializeComponent();

            // Initialize song list
            Songs = new ObservableCollection<Song>
            {
                new Song { Name = "Song 1", IsAddedToQueue = false },
                new Song { Name = "Song 2", IsAddedToQueue = false }
                // Add more songs as needed
            };

            Playlist.ItemsSource = Songs;
        }

        private async void OnBrowseLocalSongsClicked(object sender, EventArgs e)
        {
            var options = new PickOptions
            {
                PickerTitle = "Please select a music file",
                FileTypes = FilePickerFileType.Music
            };

            try
            {
                var result = await FilePicker.PickAsync(options);

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    Songs.Add(new Song { Name = result.FileName, IsAddedToQueue = false });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., permission denied or canceled file picker operation
                await DisplayAlert("Error", $"Failed to pick a file: {ex.Message}", "OK");
            }
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }

        private void OnToggleSwitchChanged(object sender, ToggledEventArgs e)
        {
            // Update the IsAddedToQueue property of the corresponding song
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is Song song)
            {
                song.IsAddedToQueue = e.Value;
            }
        }
    }

    public class Song
    {
        public string Name { get; set; }
        public bool IsAddedToQueue { get; set; }
    }
}
