using System;

namespace Lab4.tools
{
    static class Extensions
    {
        public static int Count(this String str, char delimiter)
        {
            int count = 0;
            foreach (char c in str)
                if (c == delimiter) count++;
            return count;
        }
    }
}
