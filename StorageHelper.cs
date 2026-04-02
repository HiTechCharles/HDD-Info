using System;

namespace HDD_Info
{
    /// <summary>
    /// Shared utility class for storage size formatting.
    /// </summary>
    public static class StorageHelper
    {
        private const double GB_TO_TB = 1024.0;

        /// <summary>
        /// Formats a storage size in GB to a human-readable string with appropriate units.
        /// </summary>
        /// <param name="sizeInGB">Size in gigabytes</param>
        /// <returns>Formatted string with GB or TB units</returns>
        public static string FormatStorageSize(double sizeInGB)
        {
            if (sizeInGB >= GB_TO_TB)
            {
                return $"{(sizeInGB / GB_TO_TB):N2} TB";
            }
            return $"{sizeInGB:N2} GB";
        }
    }
}