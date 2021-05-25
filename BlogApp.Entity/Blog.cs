using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entity
{
    public class Blog
    {
        public int? BLogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public bool IsSlider { get; set; }

        public int CategoryId { get; set; }
    }
}
