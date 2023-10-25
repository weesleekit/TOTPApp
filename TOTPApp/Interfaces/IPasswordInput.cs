namespace TOTPApp.Interfaces
{
    internal interface IPasswordInput
    {
        void Password(string password);
        void Cancelled();
    }
}
