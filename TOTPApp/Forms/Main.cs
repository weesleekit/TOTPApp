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
        private readonly string password;
        private DateTime? nextUpdate = null;
        private bool copyMessageActive = false;

        // Constructor

        public Main(string password, out bool success)
        {
            InitializeComponent();

            this.password = password;

            tOTPs = LoadSaveManager.LoadTotps();

            foreach (var totp in tOTPs)
            {
                if (!totp.TryUnlock(password))
                {
                    success = false;
                    Close();
                    return;
                }
            }

            success = true;

            listBoxTotps.Items.AddRange(tOTPs.ToArray());

            if (listBoxTotps.Items.Count > 0)
            {
                listBoxTotps.SelectedIndex  = 0;
            }
        }

        // Internal Methods

        internal void CreateNewTOTP(string name, string secret)
        {
            TOTPWrapper tOTP = new(name, secret, password);

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
    }
}