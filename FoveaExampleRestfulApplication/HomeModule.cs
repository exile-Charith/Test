using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoveaExampleRestfulApplication
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = x =>
            {
                var model = new { title = "Welcome From Owin Nancy Application", body = "This is the sample body of the owin application view", message="Charith Madushanka" };
                return View["home", model];
            };
        }
    }
}