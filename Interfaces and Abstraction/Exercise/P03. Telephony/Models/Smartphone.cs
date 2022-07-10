namespace Telephony.Models
{
    using Interfaces;
    public class Smartphone : ICallable, IBrowseable
    {
        public string Calling(string phoneNumber) => $"Calling... {phoneNumber}";

        public string Browsing(string url) => $"Browsing: {url}!";
    }
}
