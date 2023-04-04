using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLibrary
{
    public static class JobDistributing
    {
        static int size;
        public static bool hasJob = false;
        static int startIndex;
        static int currentIndex = 0;
        static int maxMatrCells;
        static int maxInt;
       
        public static int LastValidId { get; private set; }

        //Сюда передать Длл: и инициализировать класс
        public static void SetJob(int boardSize)
        {
            size = boardSize;
            hasJob = true;
            maxMatrCells = boardSize * boardSize;
            currentIndex = 0;


            maxInt = (int)Math.Pow(2, maxMatrCells);
        }

        //Исправить
        public static Job GetJob()
        {
            if (hasJob)
            {
                
                currentIndex += 1000000;
                
                if (currentIndex >= maxInt)
                {
                    currentIndex = maxInt - 1;
                }
                Console.WriteLine(currentIndex);
                var job = new Job()
                {
                    SizeBoard = size,
                    StartIndex = startIndex,
                    EndIndex = currentIndex
                };
                LastValidId = currentIndex;

                currentIndex = LastValidId;

                if(currentIndex + 2 >= maxInt)
                {
                    currentIndex = 0;
                    hasJob = false;
                }
                return job;
            }
            return null;
        }
    }
}
