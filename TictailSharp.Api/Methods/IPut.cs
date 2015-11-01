using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TictailSharp.Api.Methods
{
    public interface IPut<in TResource>
    {
        void Put(TResource resource);
    }
}
