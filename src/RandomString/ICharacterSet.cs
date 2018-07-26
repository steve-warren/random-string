using System;
using System.Collections.Generic;
using System.Text;

namespace RandomString
{
    public interface ICharacterSet
    {
        char GetChar(int index);
        int Length { get; }
    }
}
