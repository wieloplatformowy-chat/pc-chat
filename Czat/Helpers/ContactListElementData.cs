using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Czat.Helpers
{
    public class ContactListElementData
    {
        public long? ID;
        public string Name;
        public bool IsOnline;
        public bool IsPerson;
        public Image Avatar;

        public ContactListElementData(long? id, string name, bool isOnline, bool isPerson, Image avatar)
        {
            ID = id;
            Name = name;
            IsOnline = isOnline;
            IsPerson = isPerson;
            Avatar = avatar;
        }
    }
}
