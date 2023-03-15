using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 We’re going to create a class called StringCalculator, with a single static method with the signature static int Add(string numbers);

The method takes a string representing numbers separated by a comma, and return their sum.

If we pass an empty string, the method should return zero.

Passing a single number should result in the number itself.

The method should ignore numbers greater than 1000 should. So, “1,2,1000” should result in 1003, but “1,2,1001” should result in 3.



 */
namespace TucTesting.Services
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                 return 0;
            }

            int sum = 0;
            foreach (var tal in numbers.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var talet = Convert.ToInt32(tal);
                //if (talet > 1000) continue;
                //sum += talet;
                if(talet <= 1000)
                    sum += talet;
            }
            return sum;


            //if (numbers.Contains(','))
            //{
            //    int sum = 0;
            //    foreach (var tal in numbers.Split(',', StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        sum += Convert.ToInt32(tal);
            //    }
            //    return sum;
            //}
            //return Convert.ToInt32(numbers);
        }
    }
}
