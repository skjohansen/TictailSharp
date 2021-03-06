﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TictailSharp.Api.Methods
{
    public interface IPatch<in TResource, out TOResource>
    {
        TOResource Patch(string resourceId, TResource resource);
    }
}
