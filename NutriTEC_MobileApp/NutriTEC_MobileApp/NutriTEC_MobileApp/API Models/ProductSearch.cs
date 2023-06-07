using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace NutriTEC_MobileApp.API_Models
{
    /// <summary>
    /// The model used for the attributes of the product of the product list from the API
    /// </summary>
    public class ProductSearch
    {
        public string product_name { get; set; }
        public int barcode { get; set; }

    }
}
