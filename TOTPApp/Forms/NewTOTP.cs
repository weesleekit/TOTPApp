namespace TOTPApp.Forms
{
    public partial class NewTOTP : Form
    {
        // Fields

        private readonly Main main;

        // Constructor

        public NewTOTP(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        // UI Events

        private void NewTOTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            main.CreateNewTOTP(textBoxName.Text, textBoxSecret.Text);
            Close();
        }
    }
}
