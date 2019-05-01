using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels
{
    public class Journal
    {
        public int Id { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int StudentId { get; set; }
}
}
