using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace NutriTEC_MobileApp.API_Models
{
    public class ProductSearch
    {
        public string product_name { get; set; }
        public int barcode { get; set; }

    }
}
