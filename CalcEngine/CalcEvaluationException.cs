
namespace CalcEngine
{
    [System.Serializable]
    public class CalcEvaluationException : System.Exception
    {
        public CalcEvaluationException() { }
        public CalcEvaluationException(string message) : base(message) { }
        public CalcEvaluationException(string message, System.Exception inner) : base(message, inner) { }
        protected CalcEvaluationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}