using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ApiPM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendFileController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<string> Post([FromHeader] string source)
        {
            string fName = source.Split('\\')[source.Split('\\').Length-1];
            List<string> fNames = new List<string>();
            //Console.WriteLine(file);
            fNames.Add(fName);
            try
            {
                System.IO.File.Copy(source, @"C:\Files\"+fName,true);
                fNames.Add(fName+" [UPLOAD]");

            }
            catch (IOException copyError)
            {
                Console.WriteLine(copyError.Message);
                fNames.Add(fName + " [UPLOAD ERROR]");
            }
            return fNames;

        }
    }
}
