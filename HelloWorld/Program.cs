using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HelloWorld {
    internal class Program {
        public static void Main(string[] args) {
            // 1 byte (8 bits) unsigned, where signed means it can be nevative 
            // byte myByte = 255;
            // byte mySecondByte = 0;

            // 1 byte (8 bits) signed, where signed means it can be negative
            // sbyte mySbyte = 127;
            // sbyte mySecondSbyte = -128;

            // 2 byte (16 bits) unsigned, where signed means it can be nevative
            // ushort myUshort = 65535;

            // 2 byte (16 bits) signed, where signed means it can be negative 
            // short myShort = -32768;

            // 4 Byte (32 bits) signed, where signed means it can be nevative
            // int myInt = 2147483647;
            // int mySecondInt = -2147483647;

            // 8 Byte (64 bits) signed, where signed means it can be negative 
            // long myLong = -900000000000;

            // 4 Byte (32 bits) floating point number
            // float myFloat = 0.751f;
            // float mySecondFloat = 0.75f;

            // 8 Byte (64 bits) floating point number
            //double myDouble = 0.751;
            // double mySecondDouble = 0.75d;

            // 16 Byte (128 bits) floating point number
            // decimal myDecimal = 0.751m;
            // decimal mySecondDecimal = 0.75m;

            // Console.WriteLine(myFloat - mySecondFloat);
            // Console.WriteLine(myDouble - mySecondDouble);
            // Console.WriteLine(myDecimal - mySecondDecimal);

            // string myString = "Hello World";
            // Console.WriteLine(myString);
            // string myStringWithSimbols = "!@#$@^$%%^&12336abceujdweifw";
            // Console.WriteLine(myStringWithSimbols);

            // bool myBool = true;

            // string[] myGroceryArray = new string[2];

            // myGroceryArray[0] = "Guacamole maldito gringo";
            // myGroceryArray[1] = "HitDigs";

            // Console.WriteLine(myGroceryArray[0]);
            // Console.WriteLine(myGroceryArray[1]);

            // string[] mySecondGroceryArray = {"Apples", "Eggs"};

            // Console.WriteLine(mySecondGroceryArray[0]);
            // Console.WriteLine(mySecondGroceryArray[1]);

            /** Dynamic array or list */
            // List<string> myGroceryList = new List<string>() {"Milk", "Chease", "Potatoes"};

            // Console.WriteLine(myGroceryList[0]);
            // Console.WriteLine(myGroceryList[1]);
            // Console.WriteLine(myGroceryList[2]);

            // myGroceryList.Add("Oranges");

            // Console.WriteLine(myGroceryList[3]);

            /** */
            // IEnumerable<string> myGroceryIEnumerable = myGroceryList;
            // Console.WriteLine(myGroceryIEnumerable.First());

            /** Two dimension array */
            // string[,] myTwoDimensionalArray = new string[,] {
            //     {"Apples", "Eggs"}, 
            //     {"Milk", "Cheese"}
            // };

            // Console.WriteLine(myTwoDimensionalArray[0,0]);

            /** Dictionary */
            // Dictionary<string, string[]> myGroceryDictionary = new Dictionary<string, string[]>() {
            //     {"Dairy", new string[] {"Cheese", "Milk", "Eggs"}}
            // };

            // Console.WriteLine(myGroceryDictionary["Dairy"][1]);
        }
    }
}