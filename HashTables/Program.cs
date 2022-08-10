using System;
using System.Collections.Generic;

namespace HashTables
{

    /// <summary>
    /// The Hashtable class represents a collection of key-and-value pairs that are organized based on the hash code of the key. 
    /// It uses the key to access the elements in the collection
    /// For new code, you shouldn't use non-generic collections: Instead of HashTable use Dictionary instead
    /// --error prone
    /// --less performant generic collections have the advantage that value types don't have to be boxed as object.
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {

            #region Test dictionary example
            var books = new Dictionary<int, string>
            {
                { 3, "THE LOTR" },
                { 2, "Test book 2" },
            };
            string bookName = books[3];
            //books.Add(3, "test"); // this will not pass since it already has this key 
            #endregion


            var number1 = new PhoneMock("141804", "27", "903193232");
            var number2 = new PhoneMock("141804", "27", "903193232");
            var number3 = new PhoneMock("141804", "27", "903193232");

            Console.WriteLine(number1.GetHashCode());
            Console.WriteLine(number2.GetHashCode());

            // because they don't take objects data/properties but references, 
            // they occupy different memory address so they will be difference

            // after bool ovveride Equals it will return true
            Console.WriteLine(number1 == number2); // false
            Console.WriteLine(number1.Equals(number2)); // false

            // dictionary compares by equals and by hashCodes
            // it compares them both semantically and by hashcodes
            var customers = new Dictionary<PhoneMock, PersonHashMock>();
            customers.Add(number1, new PersonHashMock());
            customers.Add(number2, new PersonHashMock());
            Console.WriteLine("After adding phone numbers");

        }


    }
}
