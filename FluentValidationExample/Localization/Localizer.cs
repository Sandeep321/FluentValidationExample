using System;

namespace FluentValidationExample.Localization
{
    public class Localizer : ILocalizer
    {
        public string GetLocalizedString(string message)
        {
            Console.WriteLine(new System.Diagnostics.StackTrace().ToString());
            return $"Localized string for {message}";
        }
    }
}
