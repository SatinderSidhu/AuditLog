using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditLogger.Entity;

namespace AuditLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var original = new Tax()
            {
                Guid = new Guid(),
                Address = "Original address",
                Age = 36,
                Name = "Satinder Sidhu"
            };

            var changed = new Tax()
            {
                Guid = new Guid(),
                Address = "Different address",
                Age = 35,
                Name = "Satinder Sidhu"
            };

            // compare the difference in propeties 
            foreach (var oldProperty in original.GetType().GetProperties())
            {
                var oldValue = oldProperty.GetValue(original);
                var newValue = oldProperty.GetValue(changed);

                if (!object.Equals(oldValue, newValue))
                {
                    var sOldValue = oldValue == null ? "null" : oldValue.ToString();
                    var sNewValue = newValue == null ? "null" : newValue.ToString();

                    Console.WriteLine("Property " + oldProperty.Name + " was changed from : " + sOldValue + "; to: " +
                                                       sNewValue);
                }
            }


            Console.ReadKey();
        }


    }
}
