using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidopgaver
{
    class Administrating
    {
        
    }


    interface IUserControl
    {
        void CreateUser(IUser user);
    }

    class UserControl : IUserControl
    {
        private List<IUser> _users = new List<IUser>();

        public void CreateUser(IUser user)
        {
            _users.Add(user);
        }
    }

    class UserControlProxy : IUserControl
    {
        UserControl _userControl = new UserControl();

        private IUser _admin;
        public UserControlProxy(IUser admin)
        {
            _admin = admin;
        }

        public void CreateUser(IUser user)
        {
            if (_admin.IsAdmin)
            {
                _userControl.CreateUser(user);
            }
        } 
    }

    interface IUser
    {
        bool IsAdmin { get; set; }
    }

    class User : IUser
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }

    
}
