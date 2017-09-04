
namespace ERP.Common
{
    public class ComMoveCenterSoure
    {
        private static string[] soure1 = new string[] { "UP", "DOWN", "ANGLE" };
        private static string[] soure2 = new string[] { "IN", "OUT", "LENGTH" };

        public static string[] Source1
        {
            get
            {
                return soure1;
            }
        }

        public static string[] Source2
        {
            get
            {
                return soure2;
            }
        }
    }
}
