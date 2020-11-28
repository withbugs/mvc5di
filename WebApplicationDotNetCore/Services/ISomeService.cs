using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationDotNetCore.Services
{
    public interface ISomeService
    {
        string Greeting();
    }

    public interface IScopedSomeService1 : ISomeService
    {
    }
    public interface IScopedSomeService2 : ISomeService
    {
    }
}