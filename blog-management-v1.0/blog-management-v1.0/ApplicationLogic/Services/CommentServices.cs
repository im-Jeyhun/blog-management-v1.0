using blog_management_v1._0.ApplicationLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.ApplicationLogic.Services
{
    public class CommentServices
    {
        public static string GetCommentContent()
        {
            bool isEceptionValid;
            string comment = null;
            do
            {
                try
                {
                    Console.Write("Insert title : ");
                    comment = Console.ReadLine();
                    if (comment == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Seflik var");
                }

            } while (isEceptionValid || !Validations.IsLengthCorrect(comment, 10, 35));


            return comment;
        }
    }
}
