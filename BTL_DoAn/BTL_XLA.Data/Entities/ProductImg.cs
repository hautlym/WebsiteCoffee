using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Entities
{
    public class ProductImg
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; }

        public long FileSize { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
