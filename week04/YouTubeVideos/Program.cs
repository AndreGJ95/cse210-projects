using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        
        Video video1 = new Video("C# Abstraction Explained Simply", "TechWithTim", 600);
        video1.AddComment(new Comment("DevGuy99", "This finally made object-oriented programming click for me!"));
        video1.AddComment(new Comment("CodeNewbie", "Great explanation on keeping member variables private."));
        video1.AddComment(new Comment("Sarah_C", "Can you cover Encapsulation in the next video?"));
        videos.Add(video1);

        
        Video video2 = new Video("Top 10 Architectural Renderings of 2026", "DesignDigest", 840);
        video2.AddComment(new Comment("ArchiTech", "The lighting in the second project is incredible."));
        video2.AddComment(new Comment("UrbanPlanner", "Loved the integration of green spaces in the urban concept."));
        video2.AddComment(new Comment("BuildMaster", "What software was used for the 3D ray tracing?"));
        videos.Add(video2);

        
        Video video3 = new Video("How to Build a Card Game Engine", "IndieDevLogs", 1200);
        video3.AddComment(new Comment("GamerX", "The state machine for deck shuffling was super clean."));
        video3.AddComment(new Comment("PixelArtFan", "Awesome art style and UI flow."));
        video3.AddComment(new Comment("StrategyKing", "Subscribed! Looking forward to part 2."));
        video3.AddComment(new Comment("BugHunter", "Don't forget to handle null pointers on empty hands!"));
        videos.Add(video3);

        
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}