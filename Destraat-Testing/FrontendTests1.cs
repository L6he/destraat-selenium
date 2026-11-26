using System;
using System.Collections.Generic;
using System.Text;

namespace Destraat_Testing
{
    //teha omaduse testcaseordereri jaoks
    [TestCaseOrderer("Destraat_Testing.PriorityOrderer", "Destraat_Testing")] //ja panna sellele kaks argumenti
    public class FrontendTests1
    {
        [Fact] //siin on test
        [Order(1)] //järjekorranumber
        public void some_test()
        {

        }
    }
}
