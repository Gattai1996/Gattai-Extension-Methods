using System;

namespace GattaiExtensionMethods
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Round a number to a multiple of the factor.
        /// </summary>
        /// <param name="source">The number to round.</param>
        /// <param name="factor">The multiple target number.</param>
        /// <returns></returns>
        /// <example>var number = 17.5f;<br/>
        /// var newNumber = number.RoundToFactor(16); // newNumber now is 16<br/>
        /// number = 35f;<br/>
        /// number = number.RoundToFactor(16); // newNumber now is 32<br/>
        /// number = 67.9f;<br/>
        /// number = number.RoundToFactor(16); // newNumber now is 64
        /// </example>
        public static int RoundToFactor(this float source, int factor) =>
            (int)Math.Round(source / factor, MidpointRounding.AwayFromZero) * factor;
    }
}