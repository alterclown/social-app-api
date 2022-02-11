﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.Common
{
    public class Pagination
    {
        public Pagination()
        {
            CurrentPage = 0;
            ItemPerPage = 15;
            TotalItems = 0;
            TotalPages = 0;
        }
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
