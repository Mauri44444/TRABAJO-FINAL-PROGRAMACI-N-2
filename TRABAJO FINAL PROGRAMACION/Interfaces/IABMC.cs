using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    internal interface IABMC<T> : IID
    {
        void Modify ();
        void Add ();
        void Erase ();
        T Find ();
    }
}