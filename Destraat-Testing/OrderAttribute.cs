using System;
using System.Collections.Generic;
using System.Text;

namespace Destraat_Testing
{
    //järjesti klass, mis omab omadusi, mille järgi teste järjestada saab
    public class OrderAttribute : Attribute //Omadus, mille järgi me sorteerime
    {
        public int Value { get; } //väärtus, set puudub, et testimise ajal väärtust muuta ei saaks.
        public OrderAttribute(int value) //konstruktor, kus omistatakse väärtus
        {
            Value = value;
        }
    }
}
