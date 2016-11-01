﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.DataAccess.Entities
{
    public class ExifData : BaseEntity
    {
        public string ExifName { get; set; }
        public string ExifValue { get; set; }
        public virtual Photo Photo { get; set; }
    }
}