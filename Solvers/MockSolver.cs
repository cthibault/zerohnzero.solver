using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zerohnzero.solver
{
    class MockSolver : ISolver
    {
        public string Solve(string board)
        {
            return board;
        }
    }
}
