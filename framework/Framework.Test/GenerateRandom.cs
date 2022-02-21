using System;

namespace Framework.Test
{
    public static class GenerateRandom
    {
        public static string String()
        {
            var prefix = "ABC_";
            var number = new Random(0).Next(1, 10000);
            return $"{prefix}{number}";
        }
        public static int Number()
        {
            return new Random(0).Next(1, 10000);
        }
    }
}
