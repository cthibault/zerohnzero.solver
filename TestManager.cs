using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zerohnzero.solver
{
    sealed class TestManager
    {
        public TestManager(string inputBoardsFilePath) : this(inputBoardsFilePath, null) { }
        public TestManager(string inputBoardsFilePath, Action<string> outputAction)
        {
            if (string.IsNullOrWhiteSpace(inputBoardsFilePath))
            {
                throw new ArgumentNullException("inputBoardsFilePath", "Must provide a File Path to the file containing the boards to test.");
            }

            this.InputBoardsFilePath = inputBoardsFilePath;
            this.OutputAction = outputAction;
        }


        public void Initialize()
        {
            this.LoadBoards();
        }

        public List<TestResult> Execute(ISolver solver)
        {
            if (solver == null)
            {
                throw new ArgumentException("Solver must not be null.", "solver");
            }

            List<TestResult> testResults = new List<TestResult>();

            var stopwatch = new Stopwatch();

            int boardNumber = 1;
            foreach (var boardEntry in this.BoardBank)
            {
                string solution = boardEntry.Key;
                string board = boardEntry.Value;

                this.Print(string.Format("Board #{0}:  {1}", boardNumber++, board));

                stopwatch.Restart();
                string proposedSolution = solver.Solve(board);
                stopwatch.Stop();

                this.Print(string.Format("Solution:  {0}", proposedSolution));
                this.Print(string.Format("Elapsed:  {0}", stopwatch.Elapsed));

                testResults.Add(new TestResult(board, solution, proposedSolution, stopwatch.Elapsed));
            }

            return testResults;
        }

        private void LoadBoards()
        {
            if (!this.BoardBank.Any())
            {
                if (File.Exists(this.InputBoardsFilePath))
                {
                    var boardLines = File.ReadAllLines(this.InputBoardsFilePath);

                    foreach (var boardLine in boardLines)
                    {
                        var split = boardLine.Split('@');

                        this.BoardBank.Add(split[0], split[1]);
                    }
                }
                else
                {
                    throw new FileNotFoundException("File Does Not Exist.", this.InputBoardsFilePath);
                }
            }
        }

        private void Print(string message)
        {
            if (this.OutputAction != null)
            {
                this.OutputAction(message);
            }
        }


        public string InputBoardsFilePath { get; private set; }
        public Action<string> OutputAction { get; private set; }

        private Dictionary<string,string> BoardBank
        {
            get
            {
                if (this._boardBank == null)
                {
                    this._boardBank = new Dictionary<string, string>();
                }
                return this._boardBank;
            }
        }
        private Dictionary<string, string> _boardBank;
    }
}
