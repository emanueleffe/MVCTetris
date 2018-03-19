using System.Drawing;
using System.Windows.Forms;
using Tetris.View;
using Tetris.Model;

namespace Tetris.Controller
{
    class TetrisController
    {
        // Object references
        private Game game;
        private TetrisForm tView;
        private NameForm nameForm;
        private RankingForm rankingForm;
        // Drawing variables
        private Graphics g;
        private SolidBrush brush = new SolidBrush(Color.DarkSlateGray);
        private Rectangle sidebar = new Rectangle(250, 0, 125, 400);
        private Rectangle pieceContainer;
        // Images 25x25px to view the already fixed pieces
        private Image immI_25 = Properties.Resources.immI_25;
        private Image immJ_25 = Properties.Resources.immJ_25;
        private Image immL_25 = Properties.Resources.immL_25;
        private Image immO_25 = Properties.Resources.immO_25;
        private Image immS_25 = Properties.Resources.immS_25;
        private Image immT_25 = Properties.Resources.immT_25;
        private Image immZ_25 = Properties.Resources.immZ_25;
        // Functional variables
        private bool fixedPiece = false;
        private bool onPause = false;
        private int difficulty;
        // Constants
        private const int blockSize = 25;

        public TetrisController()
        {
            this.tView = new TetrisForm();
            this.tView.KeyDown += new KeyEventHandler(Tetris_Form_KeyDown);
            this.tView.Paint += new PaintEventHandler(Tetris_Form_Draw);
            this.tView.t.Tick += new System.EventHandler(Tetris_Form_Tick);
            this.tView.bShowRanking.Click += new System.EventHandler(Tetris_Form_ShowRanking);
            this.tView.bPauseResume.Click += new System.EventHandler(Tetris_Form_PauseResume);
            this.tView.Resize += new System.EventHandler(Tetris_Form_PauseResumeMinimize);
            this.tView.GotFocus += new System.EventHandler(Tetris_Form_PauseResumeGotLostFocus);
            this.tView.LostFocus += new System.EventHandler(Tetris_Form_PauseResumeGotLostFocus);
        }

        public void StartGame()
        {
            // Initialization of Game object and start of form
            this.game = new Game();
            this.tView.ShowDialog();
            this.difficulty = this.game.Difficulty;
        }

        private void Tetris_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(!onPause)
                switch (e.KeyData)
                {
                    // For each button execute the movement and update 
                    // the position of the piece where it is located and the next one
                    case Keys.Up:
                        game.RotatePiece();
                        tView.Invalidate(new Rectangle(game.CurrentPiece.X * blockSize,
                                                       game.CurrentPiece.Y * blockSize,
                                                       game.CurrentPiece.Sprite.Width,
                                                       game.CurrentPiece.Sprite.Height));
                        tView.Invalidate(pieceContainer);
                        tView.Update();
                        break;
                    case Keys.Down:
                        MoveDown();
                        break;
                    case Keys.Left:
                        game.MoveLeft();
                        tView.Invalidate(pieceContainer);
                        pieceContainer.X -= blockSize;
                        tView.Invalidate(pieceContainer);
                        tView.Update();
                        break;
                    case Keys.Right:
                        game.MoveRight();
                        tView.Invalidate(pieceContainer);
                        pieceContainer.X += blockSize;
                        tView.Invalidate(pieceContainer);
                        tView.Update();
                        break;
                }
        }

        private void Tetris_Form_PauseResumeGotLostFocus(object sender, System.EventArgs e)
        {
            if (tView.Focused == true)
                ResumeGame();
            else if (tView.Focused == false)
                PauseGame();
        }

        // Tick event: piece is moved down
        private void Tetris_Form_Tick(object sender, System.EventArgs e)
        {
            MoveDown();
        }

        private void Tetris_Form_PauseResumeMinimize(object sender, System.EventArgs e)
        {
            if (tView.WindowState == FormWindowState.Minimized)
                PauseGame();
            else if (tView.WindowState == FormWindowState.Normal)
                ResumeGame();
        }

        private void Tetris_Form_ShowRanking(object sender, System.EventArgs e)
        {
            PauseGame();
            rankingForm = new RankingForm(game.scores);
            rankingForm.bEmpty.Click += new System.EventHandler(RankingForm_Empty_Click);
            rankingForm.ShowDialog();
            ResumeGame();
        }

        private void RankingForm_Empty_Click(object sender, System.EventArgs e)
        {
            rankingForm.dataGrid.DataSource = null;
            game.scores.Clear();
            game.CreateRankingFile();
            rankingForm.dataGrid.DataSource = game.scores;
        }

        // Method to pause the game
        private void PauseGame()
        {
            onPause = true;
            tView.t.Enabled = false;
        }

        // Method to resume the game from pause
        private void ResumeGame()
        {
            onPause = false;
            tView.t.Enabled = true;
        }

        // Method to switch from pause and resume of the game
        private void PauseResumeGame()
        {
            if (tView.t.Enabled == true)
                PauseGame();
            else
                ResumeGame();
        }

        // Method that handles the click event of the form on the label bPauseResume
        private void Tetris_Form_PauseResume(object sender, System.EventArgs e)
        {
            PauseResumeGame();
        }

        // Method that deals with drawing the pieces in the Form
        private void Tetris_Form_Draw(object sender, PaintEventArgs e)
        {
            // Gestione dell'evento Paint
            e.Graphics.FillRectangle(brush, sidebar);
            DrawBlocks(g, e);
            DrawPiece(game.CurrentPiece, g, e);
            DrawNextPiece(game.NextPiece, g, e);
        }

        // Metodo per disegnare i blocchi già fissati nella griglia
        private void DrawBlocks(Graphics g, PaintEventArgs e)
        {
            for(int i = 0; i < game.GridP.Grid.GetLength(0); i++)
                for(int j = 0; j < game.GridP.Grid.GetLength(1); j++)
                    switch(game.GridP.Grid[i, j])
                    {
                        case 1:
                            e.Graphics.DrawImage(immI_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 2:
                            e.Graphics.DrawImage(immO_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 3:
                            e.Graphics.DrawImage(immL_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 4:
                            e.Graphics.DrawImage(immJ_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 5:
                            e.Graphics.DrawImage(immZ_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 6:
                            e.Graphics.DrawImage(immT_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 7:
                            e.Graphics.DrawImage(immS_25,
                                                 j * 25,
                                                 i * 25);
                            break;
            }
        }

        // Method that handles drawing of the current piece
        private void DrawPiece(Piece p, Graphics g, PaintEventArgs e)
        {
            pieceContainer = new Rectangle(game.CurrentPiece.X * blockSize,
                                           game.CurrentPiece.Y * blockSize,
                                           game.CurrentPiece.Sprite.Width,
                                           game.CurrentPiece.Sprite.Height);
            e.Graphics.DrawImage(p.Sprite,
                                 pieceContainer);
        }

        // Method that handles drawing of next piece in the sidebar
        private void DrawNextPiece(Piece p, Graphics g, PaintEventArgs e)
        {
            e.Graphics.DrawImage(p.Sprite,
                                 p.Name=='I'? 295:280,
                                 50);
        }

        // Method that deals with decrementing the timer interval in the Form
        private void DecreaseTimerInterval()
        {
            // Timer interval can't be < 200
            // The decrease steps are of 50
            if (tView.t.Interval >= 200)
                tView.t.Interval -= 50;
        }

        // Method to move down the current piece
        private void MoveDown()
        {
            // Check if the game is still valid
            if (game.InPlay)
            {
                // Check if the piece has not been fixed and in this case the piece is moved down.
                if (!fixedPiece)
                {
                    fixedPiece = game.MoveDown();
                    if (fixedPiece)
                    {
                        tView.Invalidate();
                        // If the piece has been fixed, extract the new pieces and 
                        // reinitialize the fixedPiece variable
                        game.ExtractPieces();
                        fixedPiece = false;

                        // Update the score label with the new score and check
                        // if the difficulty has increased compared to the current one
                        // if increased modify the timer interval and update the label
                        // to the current level
                        tView.Score = "Score: " + game.Score.ToString();
                        if (difficulty < game.Difficulty)
                        {
                            DecreaseTimerInterval();
                            difficulty = game.Difficulty;
                            tView.Diff = "Level: " + difficulty.ToString();
                        }
                    }
                }
            }
            else
            {
                // Case in which the game is terminated:
                // disable the timer object and show a MessageBox with the score
                // Pressing "ok" the game starts all over again and variables will be reinitializated
                this.tView.t.Enabled = false;
                MessageBox.Show("You Lost! Final score: " + game.Score);
                InsertScore();
                game.InitializeGame();
                this.tView.Initialize();
                this.tView.Invalidate();

            }
            tView.Invalidate(pieceContainer);
            pieceContainer.Y += blockSize;
            tView.Invalidate(pieceContainer);
            tView.Update();
        }

        // Method to show NameForm
        private void InsertScore()
        {
            nameForm = new NameForm();
            this.nameForm.ShowDialog();
            game.SaveScore(nameForm.Name, game.Score);
        }
    }
}
