﻿namespace PhotoShare.DataAccess.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }
        public bool Hidden { get; set; }
        public virtual User User { get; set; }
    }
}