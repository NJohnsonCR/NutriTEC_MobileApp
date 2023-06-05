using System;
using System.Collections.Generic;
using System.Text;

namespace NutriTEC_MobileApp.API_Models
{
    public class UserReturnModel
    {
        public string email { get; set; }
        public string name { get; set; }
        public string lastname1 { get; set; }
        public string lastname2 { get; set; }
        public string country { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public int calorie { get; set; }
        public string birth_date { get; set; }
        public int age { get; set; }
        public int bmi { get; set; }
    }
}
