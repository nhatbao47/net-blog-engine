﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Model
{
    public class User: IEntityBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}