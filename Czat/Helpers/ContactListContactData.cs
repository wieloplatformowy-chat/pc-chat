﻿using RestApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Czat.Helpers
{
    public class ContactListContactData
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public bool IsPerson { get; set; }
        public string Email { get; set; }
        public IList<UserDTO> Users { get; set; }
    }
}
