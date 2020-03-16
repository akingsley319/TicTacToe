using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        enum state {BLANK, X, O};
        static state turn;

        static void Main(string[] args)
        {
            Program pro = new Program();

            // Defining board
            state[][] board = new state[3][];

            // Defining Dictionary
            Dictionary<string, int> outcomes = new Dictionary<string, int>();
            outcomes.Add("X", 0);
            outcomes.Add("O", 0);
            outcomes.Add("Draw", 0);

            // Define Simulations
            for (int n = 0; n < 1000001; n++)
            {
                // Reset desired values
                turn = state.X;
                state victory = state.BLANK;
                int numberTurns = 0;

                // Reset Board
                for (int i = 0; i < 3; i++)
                {
                    board[i] = new state[] { state.BLANK, state.BLANK, state.BLANK };
                }

                // One Match in the While Loop
                while (victory == state.BLANK && numberTurns < 9)
                {
                    board = pro.Move(board);
                    victory = pro.CheckBoard(board);

                    // Change Turns
                    if (turn == state.X)
                    {
                        turn = state.O;
                    }
                    else if (turn == state.O)
                    {
                        turn = state.X;
                    }                  

                    numberTurns++;

                }

                // Record Results
                if (victory == state.BLANK)
                {
                    outcomes["Draw"]++;
                }
                else if (victory == state.X)
                {
                    outcomes["X"]++;
                }
                else if (victory == state.O)
                {
                    outcomes["O"]++;
                }
            }

            Console.WriteLine("X won " + outcomes["X"] + " times. This was " + outcomes["X"]/10000 + "% of the time.");
            Console.WriteLine("O won " + outcomes["O"] + " times. This was " + outcomes["O"]/10000 + "% of the time.");
            Console.WriteLine("There was a Draw " + outcomes["Draw"] + " times. This was " + outcomes["Draw"]/10000 + "% of the time.");

            Console.Read();
        }

        // make a move
        state[][] Move(state[][] board)
        {
            Random rand = new Random();

            int row = rand.Next(3);
            int column = rand.Next(3);

            // Checking that space is clear
            while (!board[row].Contains(state.BLANK))
            {
                row = rand.Next(3);
            }
            while (board[row][column] != state.BLANK)
            {
                column = rand.Next(3);
            }

            // Place Marker
            board[row][column] = turn;

            return board;
        }

        // check for victory
        state CheckBoard(state[][] board)
        {            
            //check horizontals
            for (int i=0; i < 3; i++)
            {
                for (int j=0; j < 3; j++)
                {
                    if(board[i][j] != turn)
                    {
                        break;
                    }
                    else if (board[i][j] == turn)
                    {
                        if (j == 2)
                        {
                            return turn;
                        }
                        else if (j != 2)
                        {
                            continue;
                        }
                    }
                }
            }

            //check verticals
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i][j] != turn)
                    {
                        break;
                    }
                    else if (board[i][j] == turn)
                    {
                        if (i == 2)
                        {
                            return turn;
                        }
                        else if (i != 2)
                        {
                            continue;
                        }
                    }
                }
            }

            //check backslash diagonal
            for (int j = 0; j < 3; j++)
            {
                if (board[j][j] != turn)
                {
                    break;
                }
                if (board[j][j] == turn)
                {
                    if (j == 2)
                    {
                        return turn;
                    }
                    else if (j != 2)
                    {
                        continue;
                    }
                }
            }

            //check forward slash diaganol
            for (int j = 0; j < 3; j++)
            {
                if (board[2 - j][j] != turn)
                {
                    break;
                }
                if (board[2 - j][j] == turn)
                {
                    if (j == 2)
                    {
                        return turn;
                    }
                    else if (j != 2)
                    {
                        continue;
                    }
                }
            }

            //victory!
            return state.BLANK;
        }
    }
}
