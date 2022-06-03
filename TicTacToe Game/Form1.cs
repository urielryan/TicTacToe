namespace TicTacToe_Game
{
    public partial class Form1 : Form
    {

        bool playerTurn = true; 
        int turn_count = 0;

        //true = X's turn to play, and false = O's turn to play

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //button's function section

        private void click_button(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (playerTurn)
                b.Text = "X";
            else
                b.Text = "O";

            //end turn
            playerTurn = !playerTurn;

            //disabling button
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            //horizontal
            if ((U001.Text == U002.Text) && (U002.Text == U003.Text) && (!U001.Enabled))
                there_is_a_winner = true;
            else if ((R001.Text == R002.Text) && (R002.Text == R003.Text) && (!R001.Enabled))
                there_is_a_winner = true;
            else if ((I001.Text == I002.Text) && (I002.Text == I003.Text) && (!I001.Enabled))
                there_is_a_winner = true;

            //vertical
            if ((U001.Text == R001.Text) && (R001.Text == I001.Text) && (!U001.Enabled))
                there_is_a_winner = true;
            else if ((U002.Text == R002.Text) && (R002.Text == I002.Text) && (!U002.Enabled))
                there_is_a_winner = true;
            else if ((U003.Text == R003.Text) && (R003.Text == I003.Text) && (!U003.Enabled))
                there_is_a_winner = true;

            //diagonal
            else if ((U001.Text == R002.Text) && (R002.Text == I003.Text) && (!U001.Enabled))
                there_is_a_winner = true;
            else if ((U003.Text == R002.Text) && (R002.Text == I001.Text) && (!I001.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disableButton();

                String winner = "";
                if (playerTurn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " ikaw ang panalo-lo-lo!", "Napaka galing!");
            }
            else
            {
                if(turn_count == 9)
                    MessageBox.Show("It's a tie!", "Ay!");
            }
        
        }
        private void disableButton()
        {
            foreach (Control c in Controls)
            {

                Button b = (Button)c;
                b.Enabled = false;
            }

        }
    }
}