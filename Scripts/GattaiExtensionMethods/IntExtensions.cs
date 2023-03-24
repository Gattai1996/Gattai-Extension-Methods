namespace GattaiExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsPair(this int source) => source % 2 == 0;
        
        public static bool IsOdd(this int source) => !IsPair(source);

        public static int ToPositive(this int source) => source * -1;
    }
}