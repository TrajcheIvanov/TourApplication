using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TourApplication.Common
{
    public static class RandomCodeGenerator
    {
        public static string RandomSixLetterCode()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var stringLength = 6;
                var bit_count = (stringLength * 6);
                var byte_count = ((bit_count + 7) / 8); // rounded up
                var bytes = new byte[byte_count];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
