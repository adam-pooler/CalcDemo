using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CalcEngine
{
    public class OperatorDefinitions : IEnumerable<KeyValuePair<string, OperatorType>>
    {
        private static readonly IDictionary<string, OperatorType> standardOperators = new Dictionary<string, OperatorType>()
        {
            { "+", OperatorType.Add },
            { "-", OperatorType.Subtract },
            { "*", OperatorType.Multiply }
        };

        private readonly IDictionary<string, OperatorType> _operatorTypeMap;

        public OperatorDefinitions()
        {
            _operatorTypeMap = standardOperators;
        }

        public OperatorDefinitions(IDictionary<string, OperatorType> operatorTypeMap)
        {
            _operatorTypeMap = operatorTypeMap ?? throw new ArgumentNullException(nameof(operatorTypeMap));
        }

        public virtual OperatorType GetOperatorType(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return _operatorTypeMap[value];
        }

        public virtual bool IsOperator(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return _operatorTypeMap.Keys.Contains(value);
        }

        public virtual IEnumerator<KeyValuePair<string, OperatorType>> GetEnumerator()
        {
            return _operatorTypeMap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_operatorTypeMap).GetEnumerator();
        }
    }

}