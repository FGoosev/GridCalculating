using Grid.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLogic
{
    public static class JobDistributing
    {
        static int size;
        static bool hasJob = false;
        static int startIndex;
        static int endIndex;
        static int currentIndex = 0;
        static int jobMaxCells = 10000;
        static int maxMatrSize;
        static int maxMatrCells;
        public static int LastValidId { get; private set; }

        public static void SetJob(int boardSize)
        {
            size = boardSize;
            hasJob = true;
            maxMatrSize = boardSize;
            maxMatrCells = boardSize * boardSize;
            currentIndex = 0;
        
        }

        //Исправить
        public static Job GetJob()
        {
            if (hasJob)
            {
                var job = new Job()
                {
                    SizeBoard = size,
                    StartIndex = startIndex,
                    EndIndex = currentIndex + 100000
                };
                LastValidId = currentIndex;

                currentIndex += 1;

                if(currentIndex >= maxMatrCells)
                {
                    currentIndex = 0;
                    currentMatrixSize++;
                    if (currentMatrixSize > maxMatrSize)
                    {
                        hasJob = false;
                    }
                }
                return job;
            }
            return null;
        }
    }
}
