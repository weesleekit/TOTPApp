using TOTPApp.Classes;

namespace TOTPApp.Forms
{
    public partial class Main : Form
    {
        // Constants

        private const double periodInSeconds = 30;
        private const int copyTextDelayInMiliseconds = 1000;

        // Fields

        private readonly List<TOTPWrapper> tOTPs = new();
        private string newpassword;
        private DateTime? nextUpdate = null;
        private bool copyMessageActive = false;

        private static DialogResult ShowPasswordInputDialog(out string password, string title, Control parent)
        {
            Size size = new(200, 70);
            Form inputBox = new()
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = size,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
            };

            TextBox textBox = new()
            {
                Size = new Size(size.Width - 10, 23),
                Location = new Point(5, 5),
                PasswordChar = '*',
                Text = ""
            };
            inputBox.Controls.Add(textBox);

            Button okButton = new()
            {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new Size(75, 23),
                Text = "&OK",
                Location = new Point(size.Width - 80 - 80, 39)
            };
            inputBox.Controls.Add(okButton);

            Button cancelButton = new()
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new Size(75, 23),
                Text = "&Cancel",
                Location = new Point(size.Width - 80, 39)
            };
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog(parent);
            password = textBox.Text;
            return result;
        }

        private bool TryUnlockUsingPassword(string password)
        {
            foreach (var totp in tOTPs)
            {
                if (!totp.TryUnlock(password))
                {
                    return false;
                }
            }

            return true;
        }


        // Constructor

        public Main()
        {
            InitializeComponent();

            tOTPs = LoadSaveManager.LoadTotps();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Hide();

            string titleMessage = tOTPs.Any() ? "Enter Password" : "Set Password";

            do
            {
                var result = ShowPasswordInputDialog(out newpassword, titleMessage, this);

                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                    return;
                }

            } while (!TryUnlockUsingPassword(newpassword));

            listBoxTotps.Items.AddRange(tOTPs.ToArray());

            if (listBoxTotps.Items.Count > 0)
            {
                listBoxTotps.SelectedIndex = 0;
            }

            Show();
        }

        // Internal Methods

        internal void CreateNewTOTP(string name, string secret)
        {
            TOTPWrapper tOTP = new(name, secret, newpassword);

            tOTPs.Add(tOTP);
            listBoxTotps.Items.Clear();
            listBoxTotps.Items.AddRange(tOTPs.ToArray());

            LoadSaveManager.SaveTotps(tOTPs);
        }

        // UI Events

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Hide();
            NewTOTP newTOTP = new(this);
            newTOTP.ShowDialog(this);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTotps.SelectedItem == null)
            {
                return;
            }

            TOTPWrapper tOTP = (TOTPWrapper)listBoxTotps.SelectedItem;

            tOTPs.Remove(tOTP);
            listBoxTotps.Items.Remove(tOTP);

            LoadSaveManager.SaveTotps(tOTPs);
        }

        private void ListBoxTotps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTotps.SelectedItem == null)
            {
                return; 
            }

            TOTPWrapper tOTP = (TOTPWrapper)listBoxTotps.SelectedItem;

            RefreshCode(tOTP);
        }

        private void TimerCodeRefresh_Tick(object sender, EventArgs e)
        {
            if (nextUpdate == null || listBoxTotps.SelectedItem == null)
            {
                textBoxTOTPCode.Text = string.Empty;
                progressBarTimeRemaining.Value = 0;
                return;
            }

            if (DateTime.UtcNow < nextUpdate)
            {
                TimeSpan remainingTime = (DateTime)nextUpdate - DateTime.UtcNow;

                double progressRatio = remainingTime.TotalSeconds / periodInSeconds;

                progressBarTimeRemaining.Value = (int)(progressRatio * 100);
                return;
            }

            TOTPWrapper tOTP = (TOTPWrapper)listBoxTotps.SelectedItem;

            RefreshCode(tOTP);
        }

        // Private Methods

        private void RefreshCode(TOTPWrapper tOTP)
        {
            string code = tOTP.GenerateCode(out int remainingSeconds);
            textBoxTOTPCode.Text = code;
            
            nextUpdate = DateTime.UtcNow.AddSeconds(remainingSeconds);
        }

        private void TextBoxTOTPCode_MouseClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(textBoxTOTPCode.Text);
            ShowLabelForTwoSeconds();
        }

        private async void ShowLabelForTwoSeconds()
        {
            if (copyMessageActive)
            {
                return;
            }

            copyMessageActive = true;
            var tempText = labelCopyHelper.Text;
            labelCopyHelper.Text = "copied";
            await Task.Delay(copyTextDelayInMiliseconds);
            labelCopyHelper.Text = tempText;
            copyMessageActive = false;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = ShowPasswordInputDialog(out newpassword, "New Password", this);

            if (result == DialogResult.Cancel)
            {
                return;
            }


            foreach (var totp in tOTPs)
            {
                totp.ChangePassword(newpassword);
            }

            LoadSaveManager.SaveTotps(tOTPs);
        }
    }
}