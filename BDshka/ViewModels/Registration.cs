﻿using BDshka.Models;
using System.Diagnostics.Contracts;

namespace BDshka.ViewModels
{
    public class Registration
    {
        public SecurityModel Security = new SecurityModel();
        public string Login;
        public string Password;
        public Registration(SecurityModel security) 
        {
            Security = security;
        }

    }
}
