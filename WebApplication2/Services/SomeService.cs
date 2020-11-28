using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class SomeService : IScopedSomeService1, IScopedSomeService2
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