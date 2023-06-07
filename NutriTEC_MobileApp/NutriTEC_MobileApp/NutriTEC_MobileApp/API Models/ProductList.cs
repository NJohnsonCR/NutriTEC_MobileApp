using System;
using System.Collections.Generic;
using System.Text;

namespace NutriTEC_MobileApp.API_Models
{
    /// <summary>
    /// The product model used for receiving the list of products from the API
    /// </summary>
    public class ProductList
    {
        public string status { get; set; }
        public List<ProductSearch> result { get; set; }
    }
}
