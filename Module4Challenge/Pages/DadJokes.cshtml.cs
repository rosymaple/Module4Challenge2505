using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Module4Challenge.Pages
{
    public class DadJokesModel : PageModel
    {
        private static readonly string[] Jokes = new[]
        {
            "Why don't eggs tell jokes? They'd crack each other up.",
            "I'm on a seafood diet. I see food and I eat it.",
            "Why did the bicycle fall over? It was two tired.",
            "What do you call fake spaghetti? An impasta.",
            "Why don't skeletons fight each other? They don't have the guts.",
            "What has 4 legs and 1 arm? A pitbull coming back from the park!",
            "Why do seagulls fly over the sea? If they flew over the bay, they'd be bagels.",
            "I only know 25 letters of the alphabet. I don't know y.",
            "What do you call a sleeping bull? A bulldozer.",
            "Why don't programmers prefer dark mode? The light attracts bugs.",
            "How does dry skin get arrested? It was cracking under pressure.",
            "Why did the scarecrow win an award? He was outstanding in his field."
        };

        public List<string> JokesToShow { get; set; } = new();

        private string lastJoke = "";
        private readonly Random rnd = new();

        public void OnGet()
        {
            DisplayJokes();
        }

        public IActionResult OnPost()
        {
            DisplayJokes();
            return Page();
        }

        private void DisplayJokes()
        {
            JokesToShow.Clear();

            for (int i = 0; i < 2; i++)
            {
                string picked;
                do
                {
                    picked = Jokes[rnd.Next(Jokes.Length)];
                }
                while (picked == lastJoke && i == 0);

                JokesToShow.Add(picked);
            }

            lastJoke = JokesToShow[1];
        }
    }
}