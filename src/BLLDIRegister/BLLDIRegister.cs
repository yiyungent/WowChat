using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;
using Autofac.Integration;

namespace BLLDIRegister
{
    public class BLLDIRegister
    {
        public void DIRegister_DAL(IServiceProvider services)
        {
            //services.Add
            var builder = new ContainerBuilder();
        }
    }
}
