using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class PostTagMap
    {
        public int PostId { get; set; }
        public Posts Post { get; set; }
        public int TagId { get; set; }
        public Tags Tag { get; set; }
    }
}
