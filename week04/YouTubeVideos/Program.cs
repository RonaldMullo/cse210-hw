using System;
using System.Collections.Generic;

// Comment
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int DurationInSeconds { get; set; }

    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int durationInSeconds)
    {
        Title = title;
        Author = author;
        DurationInSeconds = durationInSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // In this section, we create videos.
        Video video1 = new Video("How to Cook Traditional Encebollado", "Ecuadorian Flavors", 300);  
Video video2 = new Video("The Indigenous Dances of Ecuador", "Andean Culture", 600);  
Video video3 = new Video("Handmade Otavalo Market Crafts", "Explore Ecuador", 450);  
Video video4 = new Video("The Legend of Cantuña: Quito's Dark Tale", "Ecuadorian Myths", 720);  

// Adding comments  
video1.AddComment(new Comment("Maria", "This is exactly how my mom makes it in Guayaquil!"));  
video1.AddComment(new Comment("David", "I tried this recipe, and it was delicious!"));  
video1.AddComment(new Comment("Sophia", "Where can I find fresh yuca in the US?"));  

video2.AddComment(new Comment("Luis", "The Sanjuanito dance is my favorite!"));  
video2.AddComment(new Comment("Elena", "Beautiful representation of our traditions."));  
video2.AddComment(new Comment("Carlos", "I wish they showed more of the Inti Raymi festival."));  

video3.AddComment(new Comment("Andrea", "I bought a handmade poncho here last year!"));  
video3.AddComment(new Comment("Kevin", "The craftsmanship is incredible."));  
video3.AddComment(new Comment("Paula", "I dream of visiting Otavalo someday."));  

video4.AddComment(new Comment("Daniel", "This legend gives me chills every time."));  
video4.AddComment(new Comment("Isabel", "A must-know story about Quito's history."));  
video4.AddComment(new Comment("Javier", "Does anyone know if the church in the legend still exists?"));  
        
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Save the videos in a list
        foreach (var video in videos)
        {
            Console.WriteLine($"Tittle: {video.Title}");
            Console.WriteLine($"Autor: {video.Author}");
            Console.WriteLine($"Duration: {video.DurationInSeconds} segundos");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine("----------------------------------");
        }
    }
}
