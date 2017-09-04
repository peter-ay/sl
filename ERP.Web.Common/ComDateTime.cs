
using System;
namespace ERP.Web.Common
{
    public class ComDateTime
    {
        public static readonly string LongDateTime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.ToShortTimeString();
    }
}
