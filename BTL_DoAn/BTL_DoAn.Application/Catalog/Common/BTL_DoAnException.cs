using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Common
{
    internal class BTL_DoAnException:Exception
{
    public BTL_DoAnException()
    {
    }

    public BTL_DoAnException(string message)
        : base(message)
    {
    }

    public BTL_DoAnException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
}
