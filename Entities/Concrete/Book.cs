using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book : IEntity
    { 
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public string BookGenre { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
