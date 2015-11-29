using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrofsky.Photography.LUTGenerator
{
    /// <summary>
    /// Parameter validation utilities.
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Validate an integer parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter to validate.</param>
        /// <param name="value">Value of the parameter to validate.</param>
        /// <param name="minimum">The minimum allowed value (null if no minimum checking).</param>
        /// <param name="maximum">The maximum allowed value (null if no maximum checking).</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if validation fails.</exception>
        public static void CheckInteger(string paramName, int value, int? minimum = null, int? maximum = null)
        {
            if (minimum != null && value < minimum)
                throw new ArgumentOutOfRangeException(paramName, value, "Argument is below the minimum of " + minimum.ToString());
            if (maximum != null && value > maximum)
                throw new ArgumentOutOfRangeException(paramName, value, "Argument is above the maximum of " + maximum.ToString());
        }

        /// <summary>
        /// Validate an object parameter (make sure it's not null).
        /// </summary>
        /// <param name="paramName">Name of the parameter to validate.</param>
        /// <param name="value">Object to validate.</param>
        public static void CheckObject(string paramName, object value)
        {
            if (value == null)
                throw new ArgumentNullException(paramName, "Argument is null.");
        }

        /// <summary>
        /// Validate a string parameter (make sure it's not empty or null).
        /// </summary>
        /// <param name="paramName">Name of the parameter to validate.</param>
        /// <param name="value">String to validate.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void CheckString(string paramName, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName, "Argument is empty or null.");
        }
    }
}
