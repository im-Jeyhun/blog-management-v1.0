using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.ApplicationLogic.Validation
{
    public class Validations
    {
        public static bool IsLengthCorrect(string text, int startLengt, int endLength)
        {
            return text.Length >= startLengt && text.Length <= endLength;
        }
    }
}
