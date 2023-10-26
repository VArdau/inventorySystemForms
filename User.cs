using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventorySystemForms
{
    internal class User
    {
        private int ID;
        private string username;
        private string role;
        private string password;
        private string email;

        public User()
        {
            
        }
        public User(int ID, string username, string password, string role, string email)
        {
            this.ID = ID;
            this.username = username;
            this.role = role;
            this.password = password;
            this.email = email;
        }
        public User(int ID, string username, string email, string role)
        {
            this.ID = ID;
            this.username = username;
            this.role = role;
            this.email = email;
        }

        public int GetID()
        {
            return ID;
        }
        public string GetUsername()
        {
            return username;
        }
        public string GetRole()
        {
            return role;
        }
        public string GetPassword()
        {
            return password;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetRole(string role)
        {
            this.role = role;
        }
    }
}
