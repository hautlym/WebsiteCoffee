using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Entities
{
    public class News
    {
        public int NewsId { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime DatePost { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
