﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {

        }

        //required alanları görebilmek için faydası var.(required property yeni bir instance oluşunca doldurulması zorunludur demek)
        public Category(int parentId, string name, int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }

        public  int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
