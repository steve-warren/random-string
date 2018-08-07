using System;
using System.Collections.Generic;
using System.Text;

namespace RandomString
{
    public interface IRandomNumberGenerator
    {
        int Next(int maxValueExclusive);
    }
}
