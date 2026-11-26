using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Destraat_Testing
{
    //Xunit järjesti, mis implmenteerib ITestCaseOrderer liidese, ja sealt "OrderTestCases" meetodi, ning testid, nende käivitamise hetkel järjestatakse vastavalt "Order" omadusele.
    public class PriorityOrderer : ITestCaseOrderer
    {
        //meetod võtab sisse kõik testid
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            //ja tagastab nad järjestatuna arendaja defineeritud järjesti järgi.
            return testCases.OrderBy(test => 
            {
                //leitakse omadus
                var method = test.TestMethod.Method.GetCustomAttributes(typeof(OrderAttribute)).FirstOrDefault();
                //kui ei leita
                if (method == null)
                {
                    //antakse testile suurim võimalik täisarv
                    return int.MaxValue;
                }
                else
                {
                    //vastasel juhul tagastatakse omaduse order väärtus
                    return method.GetNamedArgument<int>(nameof(OrderAttribute.Value));
                }
            }
        ).ToList(); //tekitatakse loend sorteeritud testidest
        }
    }
}
