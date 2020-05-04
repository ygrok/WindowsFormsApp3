using System;
using System.Globalization;

namespace WindowsFormsApp3
{
    public class KeyboardLayout
    {
        public UInt32 Id { get; }

        public CultureInfo LanguageCultureInfo { get; }
        public CultureInfo KeyboardCultureInfo { get; }


        internal KeyboardLayout(UInt32 id, CultureInfo languageCultureInfo, CultureInfo keyboardCultureInfo)
        {
            this.Id = id;
            this.LanguageCultureInfo = languageCultureInfo;
            this.KeyboardCultureInfo = keyboardCultureInfo;

            
        }
    }
}
