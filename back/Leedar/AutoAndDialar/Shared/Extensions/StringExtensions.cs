using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shared.Extensions
{
    public static class StringExtensions
    {
        public static string NewLineAtN(this string value,int length)
        {
            int count = 0;
            foreach (var c in value)
            {
                count++;
                if (count >= length && c == ' ')
                {
                    value = value.Insert(count, "\n");
                    length += count;

                }
            }
            return value;
        }
    }
}
