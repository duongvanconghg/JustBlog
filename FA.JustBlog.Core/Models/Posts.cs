using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [Column("Short Description")]
        public string ShortDescription { get; set; }
        
        [Column("Post Content")]
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        
        [Column("Posted On")]
        public DateTime PostedOn { get; set; }

        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public ICollection<PostTagMap> postTagMaps { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}
