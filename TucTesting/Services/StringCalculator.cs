using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
