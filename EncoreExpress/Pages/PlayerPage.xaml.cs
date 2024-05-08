using CommunityToolkit.Maui.Views;
using EncoreExpress.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoreExpress.Pages
{
    public partial class PlayerPage : ContentPage
    {
        private int currentSongIndex = 0; // Index of the current song
        private bool isShuffleEnabled = false;
        private Random random = new Random();

        public PlayerPage()
        {
            InitializeComponent();

            // Add sample songs to the list
            Song song = new Song { songName = "jazz.mp3", songPath = AppDomain.CurrentDomain.BaseDirectory + "jazz.mp3" };
            App.SongList.Add(song);

            Song song1 = new Song { songName = "sound.mp3", songPath = AppDomain.CurrentDomain.BaseDirectory + "sound.mp3" };
            App.SongList.Add(song1);
            
            Song song2 = new Song { songName = "sound1.mp3", songPath = AppDomain.CurrentDomain.BaseDirectory + "sound1.mp3" };
            App.SongList.Add(song2);

            PlayCurrentSong(); // Start playing the first song
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            if (currentSongIndex == 0)
                currentSongIndex = App.SongList.Count - 1;
            else
                currentSongIndex--;
            PlayCurrentSong();
        }

        private void ShuffleButton_Clicked(object sender, EventArgs e)
        {
            isShuffleEnabled = !isShuffleEnabled;
            ShuffleSongs();
        }

        private void ShuffleSongs()
        {
            if (isShuffleEnabled)
            {
                var shuffled = App.SongList.OrderBy(x => random.Next()).ToList();
                App.SongList.Clear();
                foreach (var song in shuffled)
                {
                    App.SongList.Add(song);
                }
                currentSongIndex = 0;
                PlayCurrentSong();
            }
        }

        private void ForwardButton_Clicked(object sender, EventArgs e)
        {
            if (currentSongIndex == App.SongList.Count - 1)
                currentSongIndex = 0;
            else
                currentSongIndex++;

            PlayCurrentSong();
        }

        private void PlayCurrentSong()
        {
            string currentSongName = App.SongList[currentSongIndex].songName;
            string fileName = App.SongList[currentSongIndex].songPath;
            songNameLabel.Text = currentSongName;
            mediaElement1.Source = MediaSource.FromFile(fileName);
            mediaElement1.Play();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new PlaylistPage();
        }
    }
}

