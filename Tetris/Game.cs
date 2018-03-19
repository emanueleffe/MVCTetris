using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Tetris.Model
{
    class Game
    {
        // Object references
        private TetrisGrid g = new TetrisGrid();
        private PieceProvider provider = new PieceProvider();
        private Piece currentPiece, nextPiece;
        // Functional variables
        private bool inPlay = false;
        private int score;
        private int difficulty;
        public List<Ranking> scores = new List<Ranking>();


        // Constructor, game initialization
        public Game()
        {
            InitializeGame();
        }

        // Method to check and/or set when the game is in progress
        public bool InPlay
        {
            get
            {
                return inPlay;
            }
            set
            {
                inPlay = value;
            }
        }

        // Inizializzazione (o reinizializzazione) della partita
        // Initialization (or re-initialization) of the game
        public void InitializeGame()
        {
            currentPiece = null;
            nextPiece = null;
            g.EmptyGrid();
            inPlay = true;
            Score = 0;
            Difficulty = 1;
            ExtractPieces();
            if (!File.Exists("HighScores.xml"))
                CreateRankingFile();
            LoadScores();
        }

        public void CreateRankingFile()
        {
            XmlSerializer writer = new XmlSerializer(scores.GetType(), "Tetris.Model");
            FileStream file = File.Create("HighScores.xml");

            writer.Serialize(file, scores);
            file.Close();
        }

        private void LoadScores()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(scores.GetType(), "Tetris.Model");
                object obj;
                using (StreamReader reader = new StreamReader("HighScores.xml"))
                {
                    obj = serializer.Deserialize(reader.BaseStream);
                    reader.Close();
                }
                scores = (List<Ranking>)obj;
            }
            catch(InvalidOperationException)
            {
                CreateRankingFile();
                LoadScores();
            }            
        }

        public void SaveScore(string name, int points)
        {
            var score = new Ranking()
            {
                Score = points,
                Name = name
            };

            scores.Add(score);

            try
            {
                XmlSerializer writer = new XmlSerializer(scores.GetType(), "Tetris.Model");

                FileStream file = File.Create("HighScores.xml");

                writer.Serialize(file, scores);
                file.Close();
            }
            catch (UnauthorizedAccessException)
            {
                System.Windows.Forms.MessageBox.Show("Unable to write in 'HighScores.xml' file.\nIt's probably read-only");
            }
            catch (IOException)
            {
                System.Windows.Forms.MessageBox.Show("Unable to save 'HighScores.xml' file.\nProbably the disk is full");
            }
            
        }

        // Method to obtain the extracted piece
        public Piece CurrentPiece
        {
            get
            {
                return currentPiece;
            }
        }

        // Method to obtain the next extracted piece
        public Piece NextPiece
        {
            get
            {
                return nextPiece;
            }
        }

        // Method to end the game
        private void EndGame()
        {
            InPlay = false;
        }

        // Method to extract pieces
        public void ExtractPieces()
        {
            // if it's the first start, both pieces need to be extracted
            if (currentPiece == null && nextPiece == null)
            {
                    currentPiece = provider.ExtractPiece();
                    nextPiece = provider.ExtractPiece();
            }
            // if it's not the first start it assigns to the current piece 
            // the one previously extracted and for the next one a new one is extracted
            else
            {
                currentPiece = nextPiece;
                nextPiece = provider.ExtractPiece();
            }
        }

        // Method that returns the number of rows of the current piece
        private int RowsCurrentPiece
        {
            get
            {
                return currentPiece.Pattern.GetLength(0);
            }
        }

        // Method that returns the number of columns of the current piece
        private int ColumnsCurrentPiece
        {
            get
            {
                return currentPiece.Pattern.GetLength(1);
            }
        }

        // Method to check if a movement can be performed
        private bool CanMove(int x, int y)
        {
            bool canMove = true;

            // Check if the piece, at the given coordinates, it can fit
            for (int i = y, row = 0; i < (y + RowsCurrentPiece); i++, row++)
                for (int j = x, column = 0; j < (x + ColumnsCurrentPiece); j++, column++)
                    if ((g.Grid[i, j] != 0) && (currentPiece.Pattern[row, column] != 0))
                        canMove = false;

            return canMove;
        }

        // Method to "fix" the current piece to the grid
        private void FixPiece()
        {
            for (int i = currentPiece.Y, rowPiece = 0; i < (currentPiece.Y + RowsCurrentPiece); i++, rowPiece++)
                for (int j = currentPiece.X, columnPiece = 0; (j < (currentPiece.X + ColumnsCurrentPiece)); j++, columnPiece++)
                    if (currentPiece.Pattern[rowPiece, columnPiece] != 0)
                        g.Grid[i, j] = currentPiece.Pattern[rowPiece, columnPiece];
        }

        // Method to check if a rotation can be performed
        private bool CanRotate()
        {
            bool canRotate = true;

            // acquisition of a temporary matrix of the rotation following the current one
            int[,] rotationTemp = currentPiece.NextRotation(currentPiece.Rotation);
            // acquisition of the new x and y of the rotation
            int xNext = currentPiece.XNextRotation(), 
                yNext = currentPiece.YNextRotation();
            // Check if the next rotation comes out of the grid
            if ((yNext + rotationTemp.GetLength(0)) > g.Grid.GetLength(0))
                canRotate = false;
            if ((xNext + rotationTemp.GetLength(1)) > g.Grid.GetLength(1))
                canRotate = false;
            if (xNext < 0)
                canRotate = false;

            int i, j;
            if (canRotate)
                for (i = yNext; (i < (yNext + rotationTemp.GetLength(0))); i++)
                    for (j = xNext; (j < (xNext + rotationTemp.GetLength(1))); j++)
                        if (g.Grid[i, j] != 0)
                            canRotate = false;

            return canRotate;
        }

        // Method to move the piece to the left, called by Controller
        public void MoveLeft()
        {
            // Check that the current piece is not already on the left edge
            if (currentPiece.X != 0)
            {
                // Check if the current piece can move with the CanMove() method passing
                // to it the decreased x coordinate, y inalterated
                if (CanMove(currentPiece.X - 1, currentPiece.Y))
                {
                    // Movement valid, X decreased
                    currentPiece.X--;
                }
            }
        }

        // Method to move the piece to the right, called by Controller
        public void MoveRight()
        {
            // Check that the current piece is not already on the right edge
            if ((currentPiece.X + ColumnsCurrentPiece) < g.Grid.GetLength(1))
            {
                // Check if the current piece can move with the CanMove() method passing
                // to it the increased x coordinate, y inalterated
                if (CanMove(currentPiece.X + 1, currentPiece.Y))
                {
                    // Movement valid, X increased
                    currentPiece.X++;
                }
            }
        }

        // Method to move the piece down, called by Controller
        public bool MoveDown()
        {
            bool fixedPiece = false;

            // Check if the game is still valid
            if ((g.Grid[0, 4] != 0) || (g.Grid[0, 3] != 0))
                EndGame();
            else
            {
                // Check that the current piece is not already at the lower edge
                if (((currentPiece.Y + RowsCurrentPiece) < g.Grid.GetLength(0)) && 
                    (CanMove(currentPiece.X, currentPiece.Y + 1)))
                    currentPiece.Y++;
                else
                {
                    // The piece can no longer move, it must be "fixed" 
                    // to the underlying grid and verify that a complete line has not formed, 
                    // and in this case remove it
                    FixPiece();
                    fixedPiece = true;
                    CheckCompletedLine();
                }
            }

            return fixedPiece;
        }

        // Method to rotate the current piece, called by Controller
        public bool RotatePiece()
        {
            bool val = false;

            if (CanRotate())
            {
                currentPiece.Rotate();
                val = true;
            }

            return val;
        }

        private bool CheckCompletedLine()
        {
            bool completedLine = true;

            for (int i = 0; i < g.Grid.GetLength(0); i++)
            {
                completedLine = true;

                // Check if there's at leaste one element == 0, if any, the line is not complete
                // and the following if will be skipped. Continue to the next line (if any)
                for (int j = 0; (j < g.Grid.GetLength(1)) && (completedLine == true); j++)
                    if (g.Grid[i, j] == 0)
                        completedLine = false;
                if (completedLine)
                {
                    // Acquisition of the completed line (i) and all elements of the above
                    // line are copied on it. The same is done until you get to line 0 where
                    // it is set to 0 because everything is down one line
                    for (int k = i; k > 0; k--)
                        for (int j = 0; j < g.Grid.GetLength(1); j++)
                            g.Grid[k, j] = g.Grid[k - 1, j];
                    // set the row 0 to 0
                    for (int j = 0; j < g.Grid.GetLength(1); j++)
                        g.Grid[0, j] = 0;

                    // For each completed line the score is increased by 10
                    Score += 10;

                    // Every 100 points (10 lines completed) the difficulty increases
                    if (Score % 100 == 0)
                        Difficulty++;
                }
                
            }

            return completedLine;
        }

        public int Difficulty
        {
            get
            {
                return difficulty;
            }
            private set
            {
                difficulty = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            private set
            {
                score = value;
            }
        }

        public TetrisGrid GridP
        {
            get
            {
                return g;
            }
        }
    }
}
