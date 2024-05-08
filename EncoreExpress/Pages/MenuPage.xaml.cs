using EncoreExpress.Classes;
using System.Collections.ObjectModel;

namespace EncoreExpress.Pages;

public partial class MenuPage : ContentPage
{
	public ObservableCollection<Song> songs;
	public MenuPage()
	{
		
		InitializeComponent();
		

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
