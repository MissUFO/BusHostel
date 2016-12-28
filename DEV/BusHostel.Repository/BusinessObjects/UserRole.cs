using System;
using System.Xml.Linq;
using BusHostel.Repository.DataAccess;

namespace BusHostel.Repository.BusinessObjects
{
    /// <summary>
    /// User role
    /// </summary>
    public class UserRole : Entity
    {
        public int UserID { get; set; }
        public RoleType RoleTypeID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
     
        public UserRole() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.ID = xml.Attribute("UserRoleID").ToType<int>();
            this.UserID = xml.Attribute("UserID").ToType<int>();
            this.RoleTypeID = xml.Attribute("RoleTypeID").ToEnum<RoleType>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}