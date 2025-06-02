using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("Learning C#", "CodeAcademy", 600);
            video1.AddComment(new Comment("Alice", "Very helpful tutorial!"));
            video1.AddComment(new Comment("Bob", "I learned a lot, thanks."));
            video1.AddComment(new Comment("Charlie", "Clear and concise."));

            Video video2 = new Video("Top 10 Space Facts", "AstroWorld", 480);
            video2.AddComment(new Comment("Diana", "Amazing facts!"));
            video2.AddComment(new Comment("Eli", "I love space!"));
            video2.AddComment(new Comment("Fay", "Great visuals too."));

            Video video3 = new Video("Daily Workout Routine", "FitLife", 900);
            video3.AddComment(new Comment("George", "Burned a lot of calories."));
            video3.AddComment(new Comment("Hannah", "Will do this every morning."));
            video3.AddComment(new Comment("Ian", "Perfect length and pace."));

            Video video4 = new Video("History of the Internet", "TechTales", 720);
            video4.AddComment(new Comment("Jane", "Interesting evolution."));
            video4.AddComment(new Comment("Kyle", "Didn't know about ARPANET."));
            video4.AddComment(new Comment("Liam", "Loved the animation."));

            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);
            videos.Add(video4);

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
