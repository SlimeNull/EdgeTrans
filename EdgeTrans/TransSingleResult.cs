using System.Globalization;

namespace EdgeTrans
{
    public class TransResult
    {
        public TransResult(CultureInfo? detectedLanguage, string[] translations)
        {
            DetectedLanguage = detectedLanguage;
            Translations = translations;
        }

        public string DefaultTranslation => Translations.Length > 0 ? Translations[0] : string.Empty;

        public CultureInfo? DetectedLanguage { get; set; }
        public string[] Translations { get; set; }
    }
}