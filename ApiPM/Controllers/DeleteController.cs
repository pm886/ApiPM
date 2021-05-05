using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ApiPM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteController : ControllerBase
    {   
        [HttpDelete]
        public IEnumerable<string> Delete([FromHeader] string pattern)
        {
            //Console.WriteLine(pattern);//ex. @"test[a-z]?[01][a-z]?.[a-z]+"
           
            List<string> files = Directory.GetFiles(@"C:\Files").ToList();
            List<string> fNames = new List<string>();
            foreach (string file in files)
            {
                string fName = file.Split('\\')[file.Split('\\').Length - 1];
                if (Regex.IsMatch(fName,@pattern))
                {
                    fNames.Add(fName);
                    try
                    {
                        System.IO.File.Delete(file);
                        fNames.Add(fName+" [DELETED]");

                    }
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                        fNames.Add(fName + " [DELETED ERROR]");
                    }

                }
            }

            return fNames;

        }
    }
}
