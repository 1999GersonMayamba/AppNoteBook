using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCloudEditor.INFO
{
   public class Tb_Nota
    {
        
        public string  Nota { get; set; }
        [Unique]
        public string Titulo { get; set; }
        [PrimaryKey]
        public string Id { get; set; }
        public string Data_Nota { get; set; }
        [Ignore]
        public string Cor { get; set; }
    }
}
