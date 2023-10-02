using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Configs
{
    public class PostsConfig : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.PostContent).IsRequired();
            builder.Property(x => x.UrlSlug).IsRequired();
            builder.Property(x =>x.Published).IsRequired();
            builder.Property(x => x.PostedOn).IsRequired();
            builder.Property(x => x.Modified).IsRequired();
            
            builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId);
        }
    }
}
