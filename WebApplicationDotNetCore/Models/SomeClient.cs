﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationDotNetCore.Models
{
    public class SomeClient : ISomeClient
    {
        public string Id { get; set; }
        public SomeClient()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        //public SomeOption SomeOptions { get; set; }
    }
}