
namespace ERP.Web.DomainService.Common
{
    using System;
    using System.Net;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Web;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSGetIP : DomainService
    {
        [Invoke]
        public string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            try
            {
                var hostEntry = Dns.GetHostEntry(IP4Address);
                IP4Address += ";" + hostEntry.HostName;
            }
            catch
            {
                IP4Address += ";None";
            }

            return IP4Address;
        }
    }
}


