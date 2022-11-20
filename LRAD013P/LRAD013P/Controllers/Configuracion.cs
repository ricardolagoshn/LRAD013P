using System;
using System.Collections.Generic;
using System.Text;

namespace LRAD013P.Controllers
{
    public class Configuracion
    {
        private static string RestApiUrl = "http://{0}/{1}/{2}";

        private static String ipaddress = "192.168.0.5";
        private static String RestApi = "PRAD";
        //--------------------------------------------------------
        private static String EndpointList = "AlumnGetList.php";

        // Microservicios Crud
        public static String GetServiceList = String.Format(RestApiUrl, ipaddress, RestApi, EndpointList);
    }
}
