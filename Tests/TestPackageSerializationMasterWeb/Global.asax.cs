using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.Web;
using System;
using System.Web;

namespace TestPackageSerializationMasterWeb
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            SerializationContext.Current.Initialize(new JavaScriptSerializationStrategy());
            
            var obj = new { Name = "John", Age = 10 };
            var text = obj.Serialize();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}