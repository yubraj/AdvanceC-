using DataReaderService;
using System;
using System.Reflection;

namespace CSharpInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".........Welcome to C# Interface and Dynamic Loading Sample App............");
           
            string filePath=string.Empty;
            string input;
            bool valid=false;
            do
            {
                Console.WriteLine(".............Press 1 for Json File Or Press 2 for Csv file.................");
                input = Console.ReadLine();
                if(input=="1" || input == "2")
                {
                    valid = true;
                }
            } while (!valid);
            
            if (input == "1")
            {
                filePath = "Files/json1.json";
             
            }
            else
            {
                filePath = "Files/TextFile1.csv";
             
            }
            IDataReaderService dataReaderService = CreateDataReaderInstance("DataReaderService.DataReaderService,DataReaderService");
            Console.WriteLine(dataReaderService.ReadFile(filePath));
            Console.WriteLine(".............Thanks, Please press any key to exit.................");
            Console.ReadLine();
            
        }
        public static IDataReaderService CreateDataReaderInstance(string assemblyInfo)
        {
            Type assemblyType = Type.GetType(assemblyInfo);
            if (assemblyType != null)
            {
                Type[] argTypes = new Type[] { };

                ConstructorInfo cInfo = assemblyType.GetConstructor(argTypes);

                IDataReaderService dataReaderClass = (IDataReaderService)cInfo.Invoke(null);

                return dataReaderClass;
            }
            else
            {
                // Error checking is needed to help catch instances where
                throw new NotImplementedException();
            }
        }
    }
}
