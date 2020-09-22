using System;

namespace CalcEngine
{
    public class Node : INode, IEquatable<INode>
    {
        public Node(object value)
        {
            Value = value;
        }

        public object Value { get; protected set; }

        public virtual bool Equals(INode other)
        {
            if (other == null)
                return false;
            if (object.ReferenceEquals(this, other))
                return true;
            if (Value == null)
                return false;

            //value based equality
            return Value.Equals(other.Value);      
        }
    }
}