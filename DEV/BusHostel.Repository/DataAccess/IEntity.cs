using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BusHostel.Repository.DataAccess
{
    public interface IEntity
    {
        int ID { get; set; }
        string Name { get; set; }

        void UnpackXML(XElement xml, string childNodeName = null);
    }
}
