using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static object obj;
        public static Type type;

       
        public static int LastValidId { get; private set; }

        public static void SetJob(int boardSize, object o, Type t)
        {
            obj = o;
            type = t;
            size = boardSize;
            hasJob = true;
            maxMatrCells = boardSize * boardSize;
            currentIndex = 0;

            maxInt = (int)Math.Pow(2, maxMatrCells);
        }

        public static ImportDll GetExecute()
        {
            if(obj != null)
            {
                var exe = new ImportDll()
                {
                    Obj = obj,
                    Type = type
                };
                return exe;
            }
            return null;
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
                LastValidId = currentIndex;

                currentIndex = LastValidId;
                var job = new Job()
                {
                    SizeBoard = size,
                    StartIndex = startIndex,
                    EndIndex = currentIndex
                };

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
