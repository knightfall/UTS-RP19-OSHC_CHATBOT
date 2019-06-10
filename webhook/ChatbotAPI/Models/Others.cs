using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatbotAPI.Models
{
    public class Others
    {
        //trigger build
        public string ReturnCategory(string cat)
        {
            string response="";
            switch (cat)
            {
                case "1":
                    response = "PROFESSIONAL ATTENDANCES";
                break;
                case "2":
                    response = "ECG/Audiology/Respiratory type diagnostics";
                    break;
                case "3":
                    response = "Therapeutic Procedure";
                    break;
                case "4":
                    response = "ORAL AND MAXILLOFACIAL SERVICES";
                    break;
                case "5":
                    response = "DIAGNOSTIC IMAGING SERVICES(eg. x-ray, ultrasound, MRI, CT etc.";
                    break;
                case "6":
                    response = "PATHOLOGY SERVICES(eg. blood tests)";
                    break;
                case "7":
                    response = "CLEFT LIP AND CLEFT PALATE SERVICES";
                    break;
                case "8":
                    response = "MISCELLANEOUS SERVICES";
                    break;
                default:
                    response = "Not Found";
                    break;
            }

            return response;
        }
    }

 
}
