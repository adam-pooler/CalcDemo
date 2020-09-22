using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CalcEngine
{
    public class OperatorDefinitions : IEnumerable<KeyValuePair<string, OperatorType>>
    {
        private static readonly IDictionary<string, OperatorType> operatorTypeMap = new Dictionary<string, OperatorType>()
        {
            { "+", OperatorType.Add },
            { "-", OperatorType.Subtract },
            { "*", OperatorType.Multiply }
        };

        private static readonly OperatorDefinitions instance = new OperatorDefinitions();

        public virtual OperatorType GetOperatorType(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return operatorTypeMap[value];
        }

        public virtual bool IsOperator(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return operatorTypeMap.Keys.Contains(value);
        }

        public virtual IEnumerator<KeyValuePair<string, OperatorType>> GetEnumerator()
        {
            return operatorTypeMap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)operatorTypeMap).GetEnumerator();
        }
    }

}