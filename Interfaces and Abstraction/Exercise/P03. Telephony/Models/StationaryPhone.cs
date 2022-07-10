namespace Telephony.Models
{
    using Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Calling(string phoneNumber) => $"Dialing... {phoneNumber}";
    }
}
