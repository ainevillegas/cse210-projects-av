using System;

List<Video> videos = new List<Video>();

// Video 1
Video video1 = new Video(
    "Learn C# in 30 Minutes",
    "Code Academy",
    1800);

video1.AddComment(
    new Comment(
        "Anna",
        "Very easy to understand!"));

video1.AddComment(
    new Comment(
        "Mark",
        "Great tutorial."));

video1.AddComment(
    new Comment(
        "Sarah",
        "Helped me with my assignment."));

video1.AddComment(
    new Comment(
        "James",
        "Thanks for sharing."));

videos.Add(video1);

// Video 2
Video video2 = new Video(
    "Top 10 Coding Tips",
    "Tech World",
    1200);

video2.AddComment(
    new Comment(
        "John",
        "Tip number 5 was amazing."));

video2.AddComment(
    new Comment(
        "Maria",
        "Very informative video."));

video2.AddComment(
    new Comment(
        "David",
        "I learned a lot."));

video2.AddComment(
    new Comment(
        "Ella",
        "Please make more videos."));

videos.Add(video2);

// Video 3
Video video3 = new Video(
    "Object-Oriented Programming",
    "Programming Hub",
    2400);

video3.AddComment(
    new Comment(
        "Chris",
        "Excellent explanation."));

video3.AddComment(
    new Comment(
        "Liza",
        "Now I understand classes."));

video3.AddComment(
    new Comment(
        "Paul",
        "This was very helpful."));

video3.AddComment(
    new Comment(
        "Kevin",
        "Best OOP tutorial!"));

videos.Add(video3);

// Video 4
Video video4 = new Video(
    "GitHub for Beginners",
    "Developer Zone",
    1500);

video4.AddComment(
    new Comment(
        "Nina",
        "Perfect for beginners."));

video4.AddComment(
    new Comment(
        "Ryan",
        "I finally understand GitHub."));

video4.AddComment(
    new Comment(
        "Sophia",
        "Thank you!"));

video4.AddComment(
    new Comment(
        "Jake",
        "Very clear instructions."));

videos.Add(video4);

// Display all videos
foreach (Video video in videos)
{
    Console.WriteLine("=================================");
    Console.WriteLine($"Title: {video.GetTitle()}");
    Console.WriteLine($"Author: {video.GetAuthor()}");
    Console.WriteLine($"Length: {video.GetLength()} seconds");
    Console.WriteLine(
        $"Number of Comments: {video.GetCommentCount()}");

    Console.WriteLine("\nComments:");

    foreach (Comment comment in video.GetComments())
    {
        Console.WriteLine(
            $"{comment.GetName()}: {comment.GetText()}");
    }

    Console.WriteLine();
}