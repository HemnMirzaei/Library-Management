using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Classes
{
    public class CodeGeneration
    {
        public static string PictureCode()
        {
            Random random = new Random();
            return random.Next(100000,999999).ToString();
        }
    }
}
