
namespace Dal.Exceptions
{
    //[Serializable]
    internal class ClientExceptions : Exception
    {

    }

    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException() { }

        public ClientNotFoundException(string message)
            : base(message) { }

        public ClientNotFoundException(string message, Exception inner)
            : base(message, inner) { }

    }
}