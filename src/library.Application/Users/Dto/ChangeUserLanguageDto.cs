using System.ComponentModel.DataAnnotations;

namespace library.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}