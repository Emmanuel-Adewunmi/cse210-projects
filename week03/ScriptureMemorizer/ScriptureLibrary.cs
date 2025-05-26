using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class ScriptureLibrary
    {
        private static readonly Random _rand = new Random();
        private List<Scripture> _scriptures;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>
            {
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world that He gave His only begotten Son."
                ),
                new Scripture(
                    new Reference("Philippians", 4, 13),
                    "I can do all things through Christ who strengthens me."
                ),
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all your heart and lean not on your own understanding."
                )
            };
        }

        public Scripture GetRandomScripture()
        {
            int index = _rand.Next(_scriptures.Count);
            return _scriptures[index];
        }
    }
}
