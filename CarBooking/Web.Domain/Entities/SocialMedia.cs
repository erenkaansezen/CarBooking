﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entities
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Url { get; set; }
        
    }
}
