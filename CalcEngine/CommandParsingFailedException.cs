
namespace CalcEngine
{
    [System.Serializable]
    public class CommandParsingFailedException : System.Exception
    {
        public CommandParsingFailedException() { }
        public CommandParsingFailedException(string message) : base(message) { }
        public CommandParsingFailedException(string message, System.Exception inner) : base(message, inner) { }
        protected CommandParsingFailedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}