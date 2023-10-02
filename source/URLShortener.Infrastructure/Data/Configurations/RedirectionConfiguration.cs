using URLShortener.Core.Entities;
using URLShortener.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortener.Infrastructure.Data.Configurations
{
    public class RedirectionConfiguration : BaseConfiguration<Redirection>
    {
        public override void Configure(EntityTypeBuilder<Redirection> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.OriginalURL).HasMaxLength(Constants.Redirection.OriginalURLMaximumLength).IsRequired(Constants.Redirection.OriginalURLRequired);
            builder.Property(b => b.Slug).HasMaxLength(Constants.Redirection.SlugMaximumLength).IsRequired(Constants.Redirection.SlugRequired);
           
        }        
    }
}
