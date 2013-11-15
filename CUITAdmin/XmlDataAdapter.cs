using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace CUITAdmin {
    class XmlDataAdapter {

        XmlWriteMode schema;
        DataTable table;
        System.IO.StreamWriter writer;


        public XmlDataAdapter() {
            this.table = DBManager.Instance.GetUsers();
            table.TableName = "root";
            writer = new System.IO.StreamWriter("records.xml");
            //table = DBManager.Instance.GetUsers();
            table.WriteXml(writer, XmlWriteMode.WriteSchema);
        }



    }
}
