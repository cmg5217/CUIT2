using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUITAdmin {
    class XMLTestingClass {

        XmlManager manager;

        XMLTestingClass() {
            manager = XmlManager.Instance;
        }

        public void Test(){
            string user = "testUser" + new Random().Next();
            manager.AddUser(user, new Random().Next() + "");
            manager.AddUser(user, new Random().Next() + "");

        }
    }
}
