﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateCRUD
{
    public class Contact
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
