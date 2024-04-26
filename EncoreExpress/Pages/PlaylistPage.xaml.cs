using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Maui.Essentials;
using System.Threading.Tasks;

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
            var options = new PickOptions
            {
                PickerTitle = "Please select a music file",
                FileTypes = FilePickerFileType.MusicFiles
            };

            var result = await FilePicker.PickAsync(options);

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
               
                Songs.Add(new Song { Name = result.FileName, IsAddedToQueue = false });
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
