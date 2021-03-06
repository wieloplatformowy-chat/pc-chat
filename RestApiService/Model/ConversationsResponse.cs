﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiService.Model
{
    public class ConversationsResponse
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public IList<UserDTO> Users { get; set; }
    }
}