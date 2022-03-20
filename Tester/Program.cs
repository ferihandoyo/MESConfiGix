using System;
using System.Text;
using CIPWriter;

namespace Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object value = new float[3] { 1, 2, 3 };
            PLC myPLC=new PLC();
            myPLC.Init("192.168.0.57", 1, 3);

            string tagname = "TotalCount";

            if (myPLC.Connect())
            {
                Console.WriteLine("Connected");

                tagname = "TotalCount";
                myPLC.WriteInt(tagname, 12452);

                tagname = "tag2";
                myPLC.WriteReal(tagname, 123.44f);

                tagname = "TRK_Global_DictionaryWorkA.Items[9]";
                string text = "This is test write from C# 123";
                myPLC.WriteString(tagname, text, 3900);

                Console.ReadLine();

                myPLC.Close();
            }





        }

        

    }
}
