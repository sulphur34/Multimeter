namespace Helpers
{
    public static class FloatExtensions
    {
        public static string ToTwoDecimalString(this float value)
        {
            return value.ToString("F2");
        }
    }
}