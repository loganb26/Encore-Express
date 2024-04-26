using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncoreExpress.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentPage
    {
        public ObservableCollection<Song> Songs { get; set; }

        public PlaylistPage()
        {
            InitializeComponent();

            // Initialize your song list here
            Songs = new ObservableCollection<Song>
            {
                new Song { Name = "Song 1", IsAddedToQueue = false },
                new Song { Name = "Song 2", IsAddedToQueue = false },
                // Add more songs as needed
            };

            PlaylistView.ItemsSource = Songs;
        }

        public void OnBrowseLocalSongsClicked(object sender, EventArgs e)
        {
            // TODO: Add your code here to browse local songs
        }

        public void OnBackButtonClicked(object sender, EventArgs e)
        {
            // TODO: Add your code here to navigate back to the home page
        }
    }

    public class Song
    {
        public string Name { get; set; }
        public bool IsAddedToQueue { get; set; }
    }
}
