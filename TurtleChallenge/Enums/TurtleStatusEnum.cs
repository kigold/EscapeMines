using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Enums
{
    public enum TurtleStatusEnum : byte
    {
        [Description("Still in danger!")]
        Danger = 0,
        [Description("Success!")]
        Success,
        [Description("Mine Hit!")]
        MineHit,
    }
}
