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
    public class ListAllController : ControllerBase
    {   
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> files = Directory.GetFiles(@"D:\Files").ToList();
            List<string> fNames = new List<string>();
            foreach (string file in files)
            {
                fNames.Add(file.Split('\\')[file.Split('\\').Length - 1]);
            }

            return fNames;

        }
    }
}
