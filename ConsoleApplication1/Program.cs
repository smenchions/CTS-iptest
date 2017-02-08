using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public static class IPIdentity
    {
        /// <summary>
        /// Given an IP address in string form, determine if is it public or private. V4 or V6
        /// </summary>
        /// <param name="IPAddress">ip address string in form XXX.XXX.XXX.XXX or XXXX:XXXX.....:XXXX</param>
        /// <returns>True if public, false if private, null if invalid</returns>
        public static Boolean? isPublic(String IPAddress)
        {
            // basic check for valid input
            if (String.IsNullOrEmpty(IPAddress))
                return null;
            //check ipv6
            string[] components = IPAddress.Split(':');
            if(components.Length > 1)
            {
                if (components[0].ToUpper().StartsWith("FD"))
                    return false;
                return true;
            }
            //ipv4
            components = IPAddress.Split('.');
            // basic check for IP validity
            if (components.Length != 4)
                return null;
            if (components[0] == "10")
                return false;
            if (components[0] == "192" && components[1] == "168")
                return false;
            //only parse ints when needed for efficiency
            int classB = int.Parse(components[1]);
            if (components[0] == "172" && (classB >=16 && classB <= 31))
                return false;
            return true;
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine(IPIdentity.isPublic("123.456.789.000"));
            Console.WriteLine(IPIdentity.isPublic("192.168.789.000"));
            Console.WriteLine(IPIdentity.isPublic("10.789.000"));
            Console.WriteLine(IPIdentity.isPublic("fd20:4a55:d0f1:94b7:xxxx:xxxx:xxxx:xxxx"));
        }
    }
}
