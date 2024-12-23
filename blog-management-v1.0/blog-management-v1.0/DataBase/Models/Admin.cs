﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Models
{
    public class Admin : User
    {
        //normal admin elave elemek ucun.
        public Admin(string name, string lastName, string email, string password)
            : base(name, lastName, email, password)
        {
        }

        //sildikden sonra admin elave etmek ucun
        public Admin(string name, string lastName, string email, string password, int id)
            : base(name, lastName, email, password, id)
        {

        }

        //Update etmek ucun
        public Admin(string name, string lastName)
            : base(name, lastName)
        {

        }

        public override string GetUserInfo()
        {
            return $"Istifadeci adi : {Name} , soyadi : {LastName} , emaili : {Email} , qeydiyyat tarixi : {RegistrationDate}";

        }
    }
}
