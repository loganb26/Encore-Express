using EncoreExpress.Classes;
using System.Collections.ObjectModel;

namespace EncoreExpress.Pages;

public partial class MenuPage : ContentPage
{
	public ObservableCollection<Song> songs;
	public MenuPage()
	{
		
		InitializeComponent();
		LoadPrevSongs();

	}
	private void LoadPrevSongs()
	{
        songs = new ObservableCollection<Song>();
        if (App.SongList.Count > 0)
        {
            foreach (Song song in App.SongList)
            {
                songs.Add(song);
            }
            noSongs.Text = "";
            prevSongs.ItemsSource = songs;

        }
        else
        {
            noSongs.Text = "There are no previously played songs.";
        }
    }

    private void GoToPlayer(object sender, EventArgs e)
    {
        App.Current.MainPage = new PlayerPage();
    }

    private void GoToPlaylist(object sender, EventArgs e)
    {
        App.Current.MainPage=new PlaylistPage();
    }
}
