﻿namespace IPL.Entities
{
    public class User
    {
        public int Id {  get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; }

    }
}
