using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOTPApp.Interfaces
{
    internal interface IPasswordInput
    {
        void Password(string password);
        void Cancelled();
    }
}
