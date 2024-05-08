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

            

            //for playback speed
            PopulateSpeedOptions();
            mediaElement1.Speed = GetSelectedSpeed();
            speedPicker.SelectedIndexChanged += SpeedPicker_SelectedIndexChanged;

            //for mute option
          
            muteSwitch.Toggled += MuteSwitch_Toggled;
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
        private void PopulateSpeedOptions()
        {
            speedPicker.Items.Add("0.5x");
            speedPicker.Items.Add("0.75x");
            speedPicker.Items.Add("1.0x");
            speedPicker.Items.Add("1.25x");
            speedPicker.Items.Add("1.5x");
            speedPicker.Items.Add("2.0x");
        }
        // Event handler for speed picker selection changed
        private void SpeedPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (speedPicker.SelectedItem != null)
            {
                // Set the playback speed of the media element based on the selected value
                mediaElement1.Speed = GetSelectedSpeed();
            }
        }

        // Get the selected speed from the picker
        private double GetSelectedSpeed()
        {
            // Ensure that a default speed is returned if no item is selected
            if (speedPicker.SelectedItem == null)
            {
                return 1.0; // Default speed (1.0x)
            }

            // Extract the selected speed from the picker's selected item
            string selectedSpeedText = speedPicker.SelectedItem.ToString().Replace("x", "");
            return double.Parse(selectedSpeedText);
        }
        private void MuteSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            // Set the mute state of the media element based on the toggle switch
            mediaElement1.ShouldMute = e.Value;

            // Ensure that when ShouldMute is true, the volume is set to 0
            if (e.Value)
            {
                mediaElement1.Volume = 0;
            }
            else
            {
                // Set the volume back to normal when ShouldMute is false
                mediaElement1.Volume = 1.0;
            }
        }
        private void Menu(object sender, EventArgs e)
{
    App.Current.MainPage = new MenuPage();
}
    }
}

