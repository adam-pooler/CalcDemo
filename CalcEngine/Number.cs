using System;

namespace CalcEngine
{
    public class Number : Node
    {
        public Number(int value)
            : base(value)
        {
        }

        public Number(decimal value)
            : base(value)
        {
        }


    }
}