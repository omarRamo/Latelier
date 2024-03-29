﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.Models
{
    public class CatPicture
    {
        public int Id { get; set; }
        
        public string Url { get; set; }
        
        [IgnoreMap]
        public Score Score { get; set; }
    }
}
