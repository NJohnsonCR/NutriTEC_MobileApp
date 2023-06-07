using System;
using System.Collections.Generic;
using System.Text;

namespace NutriTEC_MobileApp.API_Models
{
    public class ProductList
    {
        public string status { get; set; }
        public List<ProductSearch> result { get; set; }
    }
}
