using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic {
    public interface IABMLogic<T> {
        List<T> GetAll();
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);

    }
}
