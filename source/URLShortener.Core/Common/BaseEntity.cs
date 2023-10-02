using URLShortener.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace URLShortener.Core
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }      
    }
}
