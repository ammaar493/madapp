using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Assignment
{
    public class Review
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(150)]
        
        public string name { get; set; }
        [MaxLength(150)]
        
        public string email { get; set; }
        [MaxLength(150)]
        
        public int contact { get; set; }
        [MaxLength(150)]
        
        public int ranking { get; set; }
        [MaxLength(150)]
        
        public string discpline { get; set; }
        [MaxLength(150)]
        
        public string longitude { get; set; }
        [MaxLength(150)]
        
        public string latitude { get; set; }
        [MaxLength(150)]
        
        public string filepath { get; set; }
        [MaxLength(150)]
        
        public string university { get; set; }
        [MaxLength(150)]

        public DateTime datetime { get; set; }

    }
}
