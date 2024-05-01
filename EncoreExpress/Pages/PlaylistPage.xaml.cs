using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Storage; // Correct namespace for file operations in MAUI
using System.Threading.Tasks;
using System;

namespace EncoreExpress.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
                new Song { Name = "Song 2", IsAddedToQueue = false },
                // Add more songs as needed
            };

            PlaylistView.ItemsSource = Songs;
        }

        public async void OnBrowseLocalSongsClicked(object sender, EventArgs e)
        {
            try
            {
                var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.audio" } }, // for iOS
                    { DevicePlatform.Android, new[] { "audio/*" } }, // for Android
                    { DevicePlatform.WinUI, new[] { ".mp3", ".wav", ".aac" } }, // for Windows
                    { DevicePlatform.MacCatalyst, new[] { "public.audio" } } // for Mac Catalyst
                });

                var options = new PickOptions
                {
                    PickerTitle = "Please select a music file",
                    FileTypes = customFileType
                };

                var result = await FilePicker.PickAsync(options);

                if (result != null)
                {
                    Songs.Add(new Song { Name = result.FileName, IsAddedToQueue = false });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error picking file: " + ex.Message);
                // Optionally, display an alert to the user
                await DisplayAlert("Error", "Failed to pick file.", "OK");
            }
        }

        public async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
    }

    public class Song
    {
        public string Name { get; set; }
        public bool IsAddedToQueue { get; set; }
    }
}
