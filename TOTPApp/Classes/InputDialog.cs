namespace TOTPApp.Classes
{
    internal static class InputDialog
    {
        internal static DialogResult ShowPasswordInputDialog(out string password, string title, Control parent)
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
    }
}
