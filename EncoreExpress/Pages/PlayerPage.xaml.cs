using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EncoreExpress.Pages
{
    public partial class PlayerPage : ContentPage
    {
        private List<string> songs = new List<string>(); // List to store song names
        private int currentSongIndex = 0; // Index of the current song
        private bool isPlaying = false; // Flag to track if the player is currently playing

        public PlayerPage()
        {
            InitializeComponent();

            // Add sample songs to the list
            songs.Add("Song 1");
            songs.Add("Song 2");
            songs.Add("Song 3");

            PlayCurrentSong(); // Start playing the first song
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            if (currentSongIndex > 0)
            {
                currentSongIndex--;
                PlayCurrentSong();
            }
        }

        private void PauseButton_Clicked(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                // Pause the playback
                pauseButton.Source = "play_50x50.png"; // Change the icon to play
                isPlaying = false;
                
            }
            else
            {
                // Resume the playback
                pauseButton.Source = "pause_50x50.png"; // Change the icon to pause
                isPlaying = true;
               
            }
        }

        private void ForwardButton_Clicked(object sender, EventArgs e)
        {
            if (currentSongIndex < songs.Count - 1)
            {
                currentSongIndex++;
                PlayCurrentSong();
            }
        }

        private void PlayCurrentSong()
        {
            // Get the current song from the list based on the current index
            string currentSongName = songs[currentSongIndex];
            // Update the Label to display the current song name
            songNameLabel.Text = currentSongName;
            // Update the Label to display the position and duration of the song
            positionLabel.Text = "0:00 / 3:30"; // Sample duration, replace with actual duration
        }

        private void PositionSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int minutes = (int)(positionSlider.Value / 60);
            int seconds = (int)(positionSlider.Value % 60);
            // Update the Label to display the current position and duration of the song
            positionLabel.Text = $"{minutes}:{seconds:D2} / 3:30"; // Sample duration, replace with actual duration
        }

        private async void AddSongButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var options = new PickOptions
                {
                    PickerTitle = "Select one or more songs"
                };
                var selectedFiles = await FilePicker.PickMultipleAsync(options);
                if (selectedFiles != null)
                {
                    foreach (var file in selectedFiles)
                    {
                        // Add the selected file to the list of songs
                        songs.Add(file.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file picking
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }
    }
}
