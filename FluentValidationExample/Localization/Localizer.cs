namespace FluentValidationExample.Localization
{
    public class Localizer : ILocalizer
    {
        public string GetLocalizedString(string message)
        {
            return $"Localized string for {message}";
        }
    }
}
