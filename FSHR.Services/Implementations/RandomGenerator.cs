using System;

namespace FSHR.Services.Implementations
{
    public class RandomGenerator : IRandomGenerator
    {
        private static readonly string _letters = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string _capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _numbers = "0123456789";
        private static readonly Random _rnd = new Random();
        public string GetCombinedLettersAndDigits(int length)
        {
            var available_lists = new[] { _letters, _capitalLetters, _numbers };

            var phrase = string.Empty;

            for (int i = 0; i < length; i++)
            {
                var list = available_lists[_rnd.Next(0, available_lists.Length)];
                phrase += list[_rnd.Next(0, list.Length)];
            }

            return phrase;
        }
    }
}