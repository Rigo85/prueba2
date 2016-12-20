using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL_BookApp
{
    public class Publisher_BEL
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public bool Active { get; set; }

        public Publisher_BEL() { }

        public Publisher_BEL(string PublisherName)
        {
            this.PublisherName = PublisherName;
        }
    }
}
