using System;

namespace Storymark.Service.Data.Configuration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLength : System.Attribute
    {
        public int Length = 0;
        public StringLength(int taggedStrLength)
        {
            Length = taggedStrLength;
        }
    }
}