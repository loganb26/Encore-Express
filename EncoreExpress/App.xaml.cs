using EncoreExpress.Classes;

namespace EncoreExpress
{
    public partial class App : Application
    {
        public static List<Song> SongList = new List<Song>();
        public App()
        {
            InitializeComponent();

            MainPage = new Pages.MenuPage();
        }
    }
}
