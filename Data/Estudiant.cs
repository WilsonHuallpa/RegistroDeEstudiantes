﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Estudiant
    {
        
        [PrimaryKey, Identity]
        public int id { set; get; }
        public string nid { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string email { set; get; }
        public byte[] image { set; get; }

    }
}
