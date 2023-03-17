using Lab.LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.Logic {
    public abstract class BaseLogic {

        protected NorthwindContext _context;

        public BaseLogic() {

            _context = new NorthwindContext();

        }
    }
}
