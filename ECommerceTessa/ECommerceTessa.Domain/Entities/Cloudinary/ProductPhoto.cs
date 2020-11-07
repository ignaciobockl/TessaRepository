using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities.Cloudinary
{
    public class ProductPhoto : UrlBase
    {
        public long ProductId { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Product Product { get; set; }
    }
}
