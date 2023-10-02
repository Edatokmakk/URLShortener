using System.ComponentModel.DataAnnotations;

namespace URLShortener.WebApi.Models
{
    public class CreateRedirectionModel
    {
        [StringLength(Constants.Redirection.OriginalURLMaximumLength, MinimumLength = Constants.Redirection.OriginalURLMinimumLength)]
        [Required]
        public string OriginalURL { get; set; }
        [StringLength(Constants.Redirection.SlugMaximumLength, MinimumLength = 0)]

        public string Slug { get; set; }
    }
}
