using Grid.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLogic
{
    public class JobExecute
    {
        public byte[] p = new byte[9];

        public int count;

        public Boolean IsLegal(int size, bool[,] cellTaken)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cellTaken[i, j])
                    {
                        //проверка строк
                        for (int r = 1; r < size; r++)
                        {
                            if (i + r < size && cellTaken[i + r, j])
                            {
                                return false;
                            }
                            if (i - r >= 0 && cellTaken[i - r, j])
                            {
                                return false;
                            }
                        }
                        //проверка столбцов
                        for (int r = 1; r < size; r++)
                        {
                            if (j + r < size && cellTaken[i, j + r])
                            {
                                return false;
                            }
                            if (j - r >= 0 && cellTaken[i, j - r])
                            {
                                return false;
                            }
                        }
                        //проверка диагоналей
                        for (int r = 1; r < size; r++)
                        {
                            if (i + r < size && j + r < size && cellTaken[i + r, j + r])
                            {
                                return false;
                            }
                            if (j + r < size && i - r >= 0 && cellTaken[i - r, j + r])
                            {
                                return false;
                            }
                            if (i + r < size && j - r >= 0 && cellTaken[i + r, j - r])
                            {
                                return false;
                            }
                            if (i - r >= 0 && j - r >= 0 && cellTaken[i - r, j - r])
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public int Execute(Job job)
        {
            var task = new JobExecute();
            bool[,] arr = new bool[job.SizeBoard, job.SizeBoard];
            var countResult = 0;
           
            int index = 0;

            for (int k = job.StartIndex; k <= job.EndIndex; k++)
            {
                var arrNumber = ConvertInt.Convert(job.SizeBoard, k);
                index = 0;
                for (int i = 0; i < job.SizeBoard; i++)
                {
                    for (int j = 0; j < job.SizeBoard; j++)
                    {
                        if (arrNumber[index] == 0)
                        {
                            arr[i, j] = false;
                        }
                        else
                        {
                            arr[i, j] = true;
                        }
                        index++;
                    }
                }
                var res = task.IsLegal(job.SizeBoard, arr);
                int flag = 0;
                if(res == true)
                {
                    foreach (var item in arr)
                    {
                        if (item == true)
                        {
                            flag++;
                        }
                    }

                    if (flag == job.SizeBoard)
                    {
                   
                        countResult++;
                    }
                }
            }
            return countResult;
        }
    }
}
