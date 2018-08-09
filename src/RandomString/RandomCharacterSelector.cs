using System;
using System.Collections.Generic;
using System.Text;

namespace RandomString
{
    public sealed class RandomCharacterSelector : IRandomCharacterSelector
    {
        private readonly char[] _set;
        private readonly Random _rnd;

        public RandomCharacterSelector(string set, Random rnd)
        {
            _rnd = rnd;
            _set = set.ToCharArray();
        }

        public char Next()
        {
            var randomIndex = _rnd.Next(0, _set.Length);

            return _set[randomIndex];
        }
    }
}
