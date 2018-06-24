using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniStore.Data
{
    public class Data
    {
        private static SoftUniStoreContext context;

        public static SoftUniStoreContext Context => context ?? (context = new SoftUniStoreContext());
    }
}
