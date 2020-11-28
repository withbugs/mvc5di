using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationDotNetCore.Models;

namespace WebApplicationDotNetCore.Services
{
    public class SomeService : ISomeService
    {
        private ISomeClient client;
        public SomeService(ISomeClient client)
        {
            this.client = client;
        }
        public string Greeting()
        {
            return $"Type: {this.client.GetType()} Id: {this.client.Id}";
        }
    }
}