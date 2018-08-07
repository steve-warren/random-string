using SecurityDriven.Inferno;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomString
{
    /// <summary>
    /// Implementation of <see cref="IRandomNumberGenerator"/> using the <see cref="CryptoRandom"/> PRNG.
    /// </summary>
    public sealed class CryptoRandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly CryptoRandom _rnd = new CryptoRandom();

        public int Next(int maxValueExclusive) => _rnd.Next(maxValueExclusive);
    }
}
