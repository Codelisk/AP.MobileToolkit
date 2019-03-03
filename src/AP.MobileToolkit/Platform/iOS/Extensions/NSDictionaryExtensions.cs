﻿using Foundation;

namespace AP.MobileToolkit.Platform.iOS.Extensions
{
    /// <summary>
    /// NSDictionary extensions.
    /// </summary>
    public static class NSDictionaryExtensions
    {
        /// <summary>
        /// Sets the value for key.
        /// </summary>
        /// <param name="dict">Dict.</param>
        /// <param name="value">Value.</param>
        /// <param name="key">Key.</param>
        public static void SetValueForKey( this NSDictionary dict, string value, string key )
        {
            dict.SetValueForKey( new NSString( value ), new NSString( key ) );
        }
    }
}