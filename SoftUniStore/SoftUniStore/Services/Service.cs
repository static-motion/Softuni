using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniStore.Services
{
    using Data;
    public abstract class Service
    {
        public Service()
        {
            this.Context = Data.Context;
        }
        protected SoftUniStoreContext Context { get; }
    }
}
