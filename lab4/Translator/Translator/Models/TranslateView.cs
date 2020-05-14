using System.ComponentModel.DataAnnotations;

namespace Translator.Models
{
    public class TranslateView
    {
        public string TranslatedWord { get; set; }
        [Required]
        public string UntranslatedWord { get; set; }
    }
}
