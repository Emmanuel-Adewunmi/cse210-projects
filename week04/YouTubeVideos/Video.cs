using System.Collections.Generic;

namespace YouTubeTracker
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthSeconds { get; set; }

        private List<Comment> comments;

        public Video(string title, string author, int lengthSeconds)
        {
            Title = title;
            Author = author;
            LengthSeconds = lengthSeconds;
            comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }
}
