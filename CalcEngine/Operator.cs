using System;
using System.Collections.Generic;

namespace CalcEngine
{
    public class Operator : Node
    {
        public Operator(OperatorType value)
            : base(value)
        {
        }
    }

}