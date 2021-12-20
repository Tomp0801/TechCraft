using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCraft.cli;

namespace Factory
{
    public class Factory
    {
        public static IGame GetGame()
        {
            return TestProgram.Test();
        }
    }
}
