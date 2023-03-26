using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLogic
{
    public static class ConvertInt
    {
        public static int[] Convert(int arrSize, int number)
        {
         
            int a = 0; // a - остаток после % деления из которого формируется число в 
                       //    двоичной системе исчисления
            int i = 0;

            int[] b = new int[arrSize * arrSize]; // массив с помощью которого двоичное число позже 
                                                  //будет выведено с конца для правильного отображения 

            int[] arr = new int[arrSize * arrSize];
            while (number >= 1)
            {
                a = number % 2;
                b[i] = a;
                i++;

                number = number / 2;

            };
            int index = 0;
            for (i = (b.Length - 1); i >= 0; i--)
            {
                arr[index] = b[i];
                index++;
            }

            return arr;
        }
    }
}
