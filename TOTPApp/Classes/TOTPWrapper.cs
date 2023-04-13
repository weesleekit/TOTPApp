using OtpNet;

namespace TOTPApp.Classes
{
    internal class TOTPWrapper
    {
        // Fields

        public string Name { get; set; }

        public string EncryptedSecret { get; set; }

        private string decryptedSecret;
        
        private Totp totp;

        // Constructor

        public TOTPWrapper()
        {

        }

        public TOTPWrapper(string name, string secret, string password) 
        {
            this.Name = name;
            
            EncryptedSecret = Encrypter.Encrypt(secret, password);

            totp = CreateTOTP(password);
        }

        // Public Methods

        internal bool TryUnlock(string password)
        {
            try
            {
                totp = CreateTOTP(password);
            }
            catch
            {
                return false;
            }

            return true;
        }

        internal string GenerateCode(out int remainingSeconds)
        {
            remainingSeconds = totp.RemainingSeconds();
            return totp.ComputeTotp();
        }

        // Private Methods

        private Totp CreateTOTP(string password)
        {
            decryptedSecret = Encrypter.Decrypt(EncryptedSecret, password);

            var secretBytes = Base32Encoding.ToBytes(decryptedSecret);

            return new(secretBytes);
        }

        // Overrides

        public override string ToString()
        {
            return Name;
        }

        internal void ChangePassword(string newpassword)
        {
            EncryptedSecret = Encrypter.Encrypt(decryptedSecret, newpassword);
        }
    }
}
