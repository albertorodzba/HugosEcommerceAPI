using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hugosEcommerce_api.DTOs;

    public class UserRegisterDTO
    {
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string passwordConfirmation {get; set;}
    }
