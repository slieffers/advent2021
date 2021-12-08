using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Code
{
    public class Day4
    {
        public static int GetWinningBoard(IEnumerable<int> numbers, IEnumerable<string> boardRows)
        {
            List<Board> boards = LoadBoards(boardRows.ToList());

            foreach (int number in numbers)
            {
                foreach (Board board in boards)
                {
                    board.RemoveDrawnNumber(number);
                    if (board.IsWinningBoard())
                    {
                        return board.SumUndrawnNumbers() * number;
                    }
                }
            }

            return -1;
        }

        public static int GetLosingBoard(IEnumerable<int> numbers, IEnumerable<string> boardRows)
        {
            List<Board> boards = LoadBoards(boardRows.ToList());

            foreach (int number in numbers)
            {
                var winningBoards = new List<Board>();
                foreach (Board board in boards)
                {
                    board.RemoveDrawnNumber(number);
                    if (board.IsWinningBoard())
                    {
                        winningBoards.Add(board);
                    }
                }

                if (boards.Count == winningBoards.Count)
                {
                    return boards.Last().SumUndrawnNumbers() * number;
                }

                boards = boards.Except(winningBoards).ToList();
            }

            return -1;
        }

        private static List<Board> LoadBoards(ICollection<string> boardRows)
        {
            List<Board> boards = new List<Board>();
            
            var count = 0;
            while (count < boardRows.Count())
            {
                var board = new Board();
                IEnumerable<string>? rows = boardRows.Skip(count).Take(5);
                foreach (string row in rows)
                {
                    board.Add(row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
                }

                boards.Add(board);
                
                count += 5;
            }

            return boards;
        }
    }

    internal class Board : List<List<int>>
    {
        public void RemoveDrawnNumber(int number)
        {
            for (var i = 0; i < Count; i++)
            {
                this[i] = this[i].Select(element => element == number ? -1 : element).ToList();
            }
        }
        
        public bool IsWinningBoard()
        {
            return HasWinningRow() || HasWinningColumn();
        }

        private bool HasWinningRow()
        {
            return this.Any(row => row.Sum() == -5);
        }

        private bool HasWinningColumn()
        {
            for(var i = 0; i < Count; i++)
            {
                if (this.All(row => row[i] == -1))
                {
                    return true;
                }
            }

            return false;
        }
        
        public int SumUndrawnNumbers()
        {
            return this.SelectMany(r =>
            {
                r.RemoveAll(element => element == -1);
                return r;
            }).Sum();
        }
    }
}