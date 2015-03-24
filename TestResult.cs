using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zerohnzero.solver
{
    class TestResult
    {
        public TestResult(string board, string solution, string proposedSolution, TimeSpan elapsedTime)
        {
            this._board = board;
            this._solution = solution;
            this._proposedSolution = proposedSolution;
            this._elapsedTime = elapsedTime;
        }

        public string Board { get { return this._board; } }
        public string Solution { get { return this._solution; } }
        public string ProposedSolution { get { return this._proposedSolution; } }
        public TimeSpan ElapsedTime { get { return this._elapsedTime; } }

        public bool IsCorrect
        {
            get
            {
                return string.Equals(this.Solution, this.ProposedSolution);
            }
        }

        private readonly string _board;
        private readonly string _solution;
        private readonly string _proposedSolution;
        private readonly TimeSpan _elapsedTime;
    }
}
