﻿using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities.Cloudinary;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Product.DTOs
{
    public class ProductDto : DtoBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public List<ProductPhoto> ProductPhoto { get; set; }

        public bool DiscountStock { get; set; }

        public bool Discontinued { get; set; }

        public bool ShowBrand { get; set; }

        public bool Slow { get; set; }

        public decimal Price1 { get; set; }

        public long BrandId { get; set; }

        public long CategoryId { get; set; }

        public int Stock1 { get; set; }

        public string ImageUrl { get; set; }
    }
}
