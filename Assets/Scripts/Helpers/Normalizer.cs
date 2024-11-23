namespace Helpers
{
    public static class Normalizer
    {
        private static readonly int _ceiling = 1;
        private static readonly int _floor = -1;

        public static int Normalize(float value)
        {
            if (value == 0)
            {
                return 0;
            }

            return value > 0 ? _ceiling : _floor;
        }
    }
}