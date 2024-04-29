using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EncoreExpress.ConsoleApp
{
    class Program
    {
        static List<Song> Songs = new List<Song>();

        static void Main(string[] args)
        {
            InitializeSongs();

            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplaySongs();
                        break;
                    case "2":
                        AddSongFromFile();
                        break;
                    case "3":
                        ToggleSongQueueStatus();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void InitializeSongs()
        {
            Songs.Add(new Song { Name = "Song 1", IsAddedToQueue = false });
            Songs.Add(new Song { Name = "Song 2", IsAddedToQueue = false });
            // Add more songs as needed
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1 - Display Songs");
            Console.WriteLine("2 - Add Song from File");
            Console.WriteLine("3 - Toggle Song Queue Status");
            Console.WriteLine("4 - Exit");
        }

        static void DisplaySongs()
        {
            Console.WriteLine("\nList of Songs:");
            foreach (var song in Songs)
            {
                Console.WriteLine($"Name: {song.Name}, In Queue: {song.IsAddedToQueue}");
            }
        }

        static async void AddSongFromFile()
        {
            Console.WriteLine("Enter file path:");
            string filePath = Console.ReadLine();
            try
            {
                var fileName = Path.GetFileName(filePath);
                Songs.Add(new Song { Name = fileName, IsAddedToQueue = false });
                Console.WriteLine("Song added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add song from file: {ex.Message}");
            }
        }

        static void ToggleSongQueueStatus()
        {
            Console.WriteLine("Enter

