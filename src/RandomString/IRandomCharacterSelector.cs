using System;
using System.Collections.Generic;
using System.Text;

namespace RandomString
{
    public interface IRandomCharacterSelector
    {
        char Next();
    }
}
