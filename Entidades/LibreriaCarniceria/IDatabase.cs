using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public interface IDatabase<T>
    {
        public List<T> GetData();

        public void Modify(T usuario);
    }
}
