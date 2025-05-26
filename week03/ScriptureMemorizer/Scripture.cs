using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private static readonly Random _rand = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text
                .Split(' ')
                .Select(word => new Word(word))
                .ToList();
        }

        public string GetDisplayText()
        {
            var text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()}\n{text}";
        }

        public void HideRandomWords(int count)
        {
            var visibleIndexes = _words
                .Select((word, index) => new { word, index })
                .Where(x => !x.word.IsHidden())
                .Select(x => x.index)
                .ToList();

            int actualHideCount = Math.Min(count, visibleIndexes.Count);
            for (int i = 0; i < actualHideCount; i++)
            {
                int randomIndex = _rand.Next(visibleIndexes.Count);
                _words[visibleIndexes[randomIndex]].Hide();
                visibleIndexes.RemoveAt(randomIndex);
            }
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden());
        }
    }
}
