using System;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();

            Dog dog1 = new Dog();
            dog1.name = "Fluor";

            //Creating new FileStream which will create new file and give ability to write in it
            using (FileStream inFile = new FileStream("dog.dat", FileMode.Create, FileAccess.Write))
            {
                //Serialazing dog1 object and saving in inFile directory "dog.dat"
                bFormatter.Serialize(inFile, dog1);
            }

            //Creating new FileStream which will open file and give ability to read it
            using (FileStream outFile = new FileStream("dog.dat", FileMode.Open, FileAccess.Read))
            {
                //Deserializng object hold in outfile directory "dog.dat" and replacing dog1 object
                dog1 = (Dog) bFormatter.Deserialize(outFile);
            }

            //Checking if the file was deserialized from file correctly
            Console.WriteLine(dog1.name);
            Console.ReadKey();
        }
    }
}
