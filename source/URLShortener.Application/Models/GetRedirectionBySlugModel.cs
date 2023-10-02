using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.Application.Models
{
    public class GetRedirectionBySlugModel
    {
        [StringLength(Constants.Redirection.SlugMaximumLength, MinimumLength = Constants.Redirection.SlugMinimumLength)]
        [Required]
        public string Slug { get; set; }
    }
}
