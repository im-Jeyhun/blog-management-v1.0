﻿using blog_management_v1._0.DataBase.Models.Common;
using blog_management_v1._0.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Models
{
    public class User : Entity<int>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        protected DateTime RegistrationDate { get; } = DateTime.Now;


      //bu sildikden sonra elavet etmek ucun
        public User(string name, string lastName, string email, string password, int? id = null)
        {

            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            if (id != null)
            {

                Id = id.Value;
            }
            else
            {

                Id = UserRepository.IdCounter;
            }


        }
   
        public User(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public virtual string GetUserInfo()
        {
            return $"{Id}Istifadeci adi : {Name} , soyadi : {LastName} , emaili : {Email} ";

        }
    }
}
