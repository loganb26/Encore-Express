using CommunityToolkit.Maui.Views;
using EncoreExpress.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace EncoreExpress.Pages
{
    public partial class PlayerPage : ContentPage
    {

        private int currentSongIndex = 0; // Index of the current song
        private bool isPlaying = false; // Flag to track if the player is currently playing

        
        public PlayerPage()
        {
            InitializeComponent();

            // Add sample songs to the list
            Song song = new Song();
            song.songName = "jazz.mp3";
            song.songPath = "E:\\downloads\\Encore-Express-master\\Encore-Express-master\\EncoreExpress\\Resources\\Raw\\jazz.mp3";
            App.SongList.Add(song);
            Song song1 = new Song();
            song1.songName = "sound.mp3";
            song1.songPath = "E:\\downloads\\Encore-Express-master\\Encore-Express-master\\EncoreExpress\\Resources\\Raw\\sound.mp3";
            App.SongList.Add(song1);
            Song song2 = new Song();
            song2.songName = "sound1.mp3";
            song2.songPath = "E:\\downloads\\Encore-Express-master\\Encore-Express-master\\EncoreExpress\\Resources\\Raw\\sound1.mp3";
            App.SongList.Add(song2);
            /*songs.Add("jazz.mp3");
            songs.Add("sound.mp3");
            songs.Add("sound1.mp3");*/

            PlayCurrentSong(); // Start playing the first song
        }

       




        private void BackButton_Clicked(object sender, EventArgs e)
        {
            if (currentSongIndex == 0)
            {
                currentSongIndex = App.SongList.Count - 1; // Set index to the last song
            }
            else
            {
                currentSongIndex--;
            }
            PlayCurrentSong();
        }

        private void ForwardButton_Clicked(object sender, EventArgs e)
        {

            if (currentSongIndex == App.SongList.Count - 1)
            {
                currentSongIndex = 0; // Set index to the first song
            }
            else
            {
                currentSongIndex++;
            }
            PlayCurrentSong();
        }

        private void PlayCurrentSong()
        {
            // Get the current song from the list based on the current index
            string currentSongName = App.SongList[currentSongIndex].songName;
            string fileName = App.SongList[currentSongIndex].songPath;
            // Update the Label to display the current song name
            songNameLabel.Text = currentSongName;
            mediaElement1.Source = MediaSource.FromFile(fileName); 
            mediaElement1.Play();

            
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
                        //songs.Add(file.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file picking
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new PlaylistPage();
        }


    }
}
