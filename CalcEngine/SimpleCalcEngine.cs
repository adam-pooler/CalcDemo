using System.Collections.Generic;
using System;

namespace CalcEngine
{
    public class SimpleCalcEngine : Evaluator
    {
        public SimpleCalcEngine()
        {
        }

        protected override void EvaluateNode(LinkedListNode<INode> element, ref object result)
        {
            if (element == null || element.Value == null)
                throw new ArgumentOutOfRangeException(nameof(element));

            if (element.Previous == null)
            {
                if (element.Value is Number)
                    result = element.Value.Value;
                else
                    throw new CalcEvaluationException("Invalid expression format: expected numeric term");
            }
            else if (element.Value is Number)
            {
                if (!(element.Previous.Value is Operator))
                    throw new CalcEvaluationException("Invalid expression format: expected operator preceding this term");
                
                Operator op = (Operator)element.Previous.Value;
                Number num = (Number)element.Value;

                if ((result is int) && (num.Value is int))
                    result = Calculate((int)result, (int)num.Value, (OperatorType)op.Value);
                else if ((result is decimal) || (num.Value is decimal))
                    result = Calculate(Convert.ToDecimal(result), Convert.ToDecimal(num.Value), (OperatorType)op.Value); 
                else
                    throw new CalcEvaluationException("Invalid expression format: expected types int or decimal");
            }
        }

        protected virtual int Calculate(int first, int second, OperatorType op)
        {
            switch (op)
            {
                case OperatorType.Add:
                    return first + second;
                case OperatorType.Subtract:
                    return first - second;
                case OperatorType.Multiply:
                    return first * second;
                default:
                    throw new ArgumentOutOfRangeException(nameof(op));
            }
        }

        protected virtual decimal Calculate(decimal first, decimal second, OperatorType op)
        {
            switch (op)
            {
                case OperatorType.Add:
                    return first + second;
                case OperatorType.Subtract:
                    return first - second;
                case OperatorType.Multiply:
                    return first * second;
                default:
                    throw new ArgumentOutOfRangeException(nameof(op));
            }       
        }
    }
}