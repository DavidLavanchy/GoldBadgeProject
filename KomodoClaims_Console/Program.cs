using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            DateTime ClaimDate = new DateTime(04 / 03 / 2020);
            DateTime IncidentDate = new DateTime(03 / 20 / 2020);

            if ((ClaimDate <= IncidentDate) && (ClaimDate >= IncidentDate.Date.AddDays(-30))) 
            {
                Console.WriteLine("true"); 
            }

            else 
            {
                Console.WriteLine("false");
            };
            Console.ReadLine();

        }
        
    }
}
