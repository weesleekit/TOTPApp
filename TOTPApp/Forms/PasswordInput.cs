namespace TOTPApp.Forms
{
    public partial class PasswordInput : Form
    {
        public PasswordInput()
        {
            InitializeComponent();
        }

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            string password = textBoxPassword.Text;

            Main main = new (password, out bool success);
            
            if (!success)
            {
                MessageBox.Show("Invalid password");
                return;
            }

            Hide();
            main.ShowDialog(this);
            Close();
        }
    }
}
