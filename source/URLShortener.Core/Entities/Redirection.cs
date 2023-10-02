using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortener.Core.Entities
{
    public class Redirection : BaseEntity
    {       
        public string OriginalURL { get; set; }
        public string Slug { get; set; }
    }
}
