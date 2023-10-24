using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotWeEat.Domain.Enum
{
    [Flags]
    public enum Season
    {
        Spring = 1,
        Summer = 4,
        Autumn = 8,
        Winter = 16,
    }
}
