﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoShare.DataAccess.Entities;

namespace PhotoShare.Models
{
    public class MessageModel
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
    }
}