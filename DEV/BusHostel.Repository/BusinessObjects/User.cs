using System;
using System.Collections.Generic;
using BusHostel.Repository.DataAccess;
using System.Xml.Linq;

namespace BusHostel.Repository.BusinessObjects
{
    /// <summary>
    /// User object
    /// </summary>
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime LastLoginOn { get; set; }

        public DateTime LastPasswordChangedOn { get; set; }

        public int FailedPasswordAttemptCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public UserStatus StatusID { get; set; }

        public List<UserRole> Role { get { return _role; } set { _role = value; } }
        private List<UserRole> _role = new List<UserRole>();

        public User() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.ID = xml.Attribute("UserID").ToType<int>();
            this.FirstName = xml.Attribute("FirstName").ToType<string>();
            this.LastName = xml.Attribute("LastName").ToType<string>();
            this.Name = this.FirstName + " " + this.LastName;
            this.Login = xml.Attribute("Login").ToType<string>();
            this.Password = xml.Attribute("Password").ToType<string>();
            this.LastLoginOn = xml.Attribute("LastLoginOn").ToType<DateTime>();
            this.LastPasswordChangedOn = xml.Attribute("LastPasswordChangedOn").ToType<DateTime>();
            this.FailedPasswordAttemptCount = xml.Attribute("FailedPasswordAttemptCount").ToType<int>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.StatusID = xml.Attribute("StatusID").ToEnum<UserStatus>();
            
            this.Role.UnpackXML<UserRole>(xml);
        }

        public void AddRole(UserRole role)
        {
            if (Role == null)
                Role = new List<UserRole>();

            if (Role.Contains(role) == false)
                Role.Add(role);
        }
    }
}
