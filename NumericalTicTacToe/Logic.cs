using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalTicTacToe
{
    class Logic
    {
        int[,] board;

        public Logic(int[,]board)
        {
            this.board = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this.board[i, j] = board[i, j];
        }

        public void setBoard(int[,]board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this.board[i, j] = board[i, j];
        }

        private int[] findNumbers()
        {
            int[] numbers = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int c = 9;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this.board[i, j] != 0)
                    {
                        numbers[this.board[i, j] - 1] = 0;
                        c--;
                    }
            int[] goodNumbers = new int[c];
            int x = 0;
            for (int i = 0; i < 9; i++)
                if (numbers[i] != 0)
                {
                    goodNumbers[x] = numbers[i];
                    x++;
                }
            return goodNumbers;
        }

        public String checkWinner(int t, int i, int j)
        {
            int val = t % 2;
            String str = this.checkRow(i);
            if (str != "no")
                return str;
            str = this.checkCol(j);
            if (str != "no")
                return str;
            if (i + j == 2)
            {
                str = this.checkClimb();
                if (str != "no")
                    return str;
            }
            if (i == j)
            {
                str = this.checkSlope();
                if (str != "no")
                    return str;
            }
            if (t == 9)
                return "tie";
            return "no";
        }

        private String checkRow(int i)
        {
            int c = 0;
            String str = "";
            for (int j = 0; j < 3; j++)
            {
                if (this.board[i, j] == 0)
                    return "no";
                c += this.board[i, j];
                str += i.ToString() + j;
            }
            if (c == 15)
                return str;
            return "no";
        }

        private String checkCol(int j)
        {
            int c = 0;
            String str = "";
            for (int i = 0; i < 3; i++)
            {
                if (this.board[i, j] == 0)
                    return "no";
                c += this.board[i, j];
                str += i.ToString() + j;
            }
            if (c == 15)
                return str;
            return "no";
        }

        private String checkClimb()
        {
            int c = 0, i = 2;
            for (int j = 0; j < 3; j++)
            {
                if (this.board[i, j] == 0)
                    return "no";
                c += this.board[i, j];
                i--;
            }
            if (c == 15)
                return "201102";
            return "no";
        }

        private String checkSlope()
        {
            int c = 0, i = 0;
            for (int j = 0; j < 3; j++)
            {
                if (this.board[i, j] == 0)
                    return "no";
                c += this.board[i, j];
                i++;
            }
            if (c == 15)
                return "001122";
            return "no";
        }

        private int evaluate(int t, String winner)
        {
            if (winner == "tie")
                return 0;
            if (t % 2 == 0)
                return 1;
            return -1;
        }

        private int minmax(int t, bool player, int[] numbersLeft, int q, int w)
        {
            String winner = this.checkWinner(t, q, w);
            if (winner != "no")
                return this.evaluate(t, winner);
            int score;
            if (!player)
            {
                int max = -10;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (this.board[i, j] == 0)
                            for (int x = 0; x < numbersLeft.Length; x++)
                                if (numbersLeft[x] != 0 && numbersLeft[x] % 2 == 0)
                                {
                                    this.board[i, j] = numbersLeft[x];
                                    numbersLeft[x] = 0;
                                    score = this.minmax(t + 1, !player, numbersLeft, i, j);
                                    if (score > max)
                                        max = score;
                                    numbersLeft[x] = this.board[i, j];
                                    this.board[i, j] = 0;
                                    if (max == 1)
                                    {
                                        x = 10;
                                        i = 3;
                                        j = 3;
                                    }
                                }
                return max;
            }
            else
            {
                int min = 10;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (this.board[i, j] == 0)
                            for (int x = 0; x < numbersLeft.Length; x++)
                                if (numbersLeft[x] != 0 && numbersLeft[x] % 2 == 1)
                                {
                                    this.board[i, j] = numbersLeft[x];
                                    numbersLeft[x] = 0;
                                    score = this.minmax(t + 1, !player, numbersLeft, i, j);
                                    if (score < min)
                                        min = score;
                                    numbersLeft[x] = this.board[i, j];
                                    this.board[i, j] = 0;
                                    if (min == -1)
                                    {
                                        x = 10;
                                        i = 3;
                                        j = 3;
                                    }
                                }
                return min;
            }
        }

        public int[] AIPerformMove(int turn)
        {
            int[] numbersLeft = this.findNumbers();
            int bestScore = -10, score = 0, bestI = 0, bestJ = 0, bestX = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this.board[i, j] == 0)
                        for (int x = 0; x < numbersLeft.Length; x++)
                            if (numbersLeft[x] % 2 == 0)
                            {
                                this.board[i, j] = numbersLeft[x];
                                numbersLeft[x] = 0;
                                score = this.minmax(turn, true, numbersLeft, i, j);
                                if (score > bestScore)
                                {
                                    bestScore = score;
                                    bestI = i;
                                    bestJ = j;
                                    bestX = x;
                                }
                                numbersLeft[x] = this.board[i, j];
                                this.board[i, j] = 0;
                                if (bestScore == 1)
                                {
                                    x = 10;
                                    i = 3;
                                    j = 3;
                                }
                            }
            int[] move = new int[3] { bestI, bestJ, numbersLeft[bestX] };
            return move;
        }
    }
}