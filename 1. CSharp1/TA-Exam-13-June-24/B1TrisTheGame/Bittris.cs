﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace B1TrisTheGame
{
    class Bittris
    {
        public class PlayerArea
        {
            public int CanvasWidth;
            public int CanvasHeight;

            public int Width;
            public int Height;

            public int TopRow;
            public int BotRow;

            public PlayerArea()
            {
                this.CanvasWidth = 36;
                this.CanvasHeight = 36;

                this.Width = CanvasWidth * 1;
                this.Height = CanvasHeight * (5 / 6);

                this.TopRow = (CanvasHeight - Height) / 2;
                this.BotRow = CanvasHeight - (CanvasHeight - Height) / 2;
            }

        }



        public class Pieces
        {
            public int posRow = 0; //row
            public int posCol = 20; //col
            public int vSpeed = 1;
            public int hSpeed = 0;
            public string toPrint = "";
            public int stringLength;
            public int Score;
            public ConsoleColor Color;
            public bool isMoving = true;

            public Pieces(int rndNumber)
            {
                //TODO: ADD COLORS, Start Position
                this.toPrint = (Convert.ToString(rndNumber, 2).
                    PadLeft(32, '0')).
                    Substring(24, 8); // conver to binary
                this.toPrint = this.toPrint.TrimStart('0');
                this.toPrint = this.toPrint.TrimEnd('0');

                //get score ( number of ones )
                foreach (char digit in this.toPrint)
                { if (digit == '1') { this.Score++; } }

            }

        }

        class Player
        {
            public string Name = "";
            public int Score = 0;
            public ConsoleKeyInfo Input = new ConsoleKeyInfo();
            public Pieces activePiece;

            public Player(string cName)
            {
                this.Name = cName;
            }

            public Player()
            {
                this.Name = "Player1";
            }
        }

        static void Main()
        {
            //settings
            Console.Clear();

            PlayerArea playArea = new PlayerArea();

            Console.BufferWidth = Console.WindowWidth = playArea.CanvasWidth;
            Console.BufferHeight = Console.WindowHeight = playArea.CanvasHeight;

            Console.Title = "B1tTris The Game";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            Console.Clear();

            int appSpeed = 200;
            bool appIsRunning = true;

            Random mainRandomizer = new Random();
            // end settings

            //variables
            List<Pieces> staticPieces = new List<Pieces>();

            Player player1 = new Player();
            //end variables

            while (appIsRunning)
            {
                //Create a new Shape
                player1.activePiece = new Pieces(mainRandomizer.Next(0, Int32.MaxValue));

                //MAIN
                while (player1.activePiece.isMoving)
                {
                    //read player input
                    while (Console.KeyAvailable)
                    {
                        player1.Input = Console.ReadKey();
                    }
                    //Change Position
                    switch (player1.Input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            player1.activePiece.hSpeed = -1;
                            player1.Input = new ConsoleKeyInfo();
                            break;
                        case ConsoleKey.RightArrow:
                            player1.activePiece.hSpeed = 1;
                            player1.Input = new ConsoleKeyInfo();
                            break;
                    }
                    //check if position left or right is free
                    if (CheckSides(player1.activePiece, staticPieces))
                    {
                        player1.activePiece.posCol += player1.activePiece.hSpeed; //move the piece
                        player1.activePiece.hSpeed = 0;
                    }
                    else
                    {
                        player1.activePiece.hSpeed = 0; //ignore input
                    }

                    Console.SetCursorPosition(player1.activePiece.posCol, player1.activePiece.posRow);
                    Console.Write(player1.activePiece.toPrint);

                    Thread.Sleep(appSpeed);
                }

                Thread.Sleep(appSpeed);
            }

        }

        public static bool CheckSides(Pieces currElement, List<Pieces> existingPieces)
        {
            //TODO 
            //1. Check Outside of player Area

            bool result = true;

            // each existing piece
            if (currElement.hSpeed < 0) //check Left
            {
                foreach (Pieces piece in existingPieces)
                {
                    if (piece.posRow == currElement.posRow)
                    {
                        if (piece.posCol + piece.stringLength >=
                            currElement.posCol + currElement.hSpeed) ;
                        {
                            result = false;
                        }
                    }
                }
            }
            else //Check Right
            {
                foreach (Pieces piece in existingPieces)
                {
                    if (piece.posRow == currElement.posRow)
                    {
                        if (piece.posCol <=
                            currElement.posCol + currElement.stringLength
                            + currElement.hSpeed) ;
                        {
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

    }
}
