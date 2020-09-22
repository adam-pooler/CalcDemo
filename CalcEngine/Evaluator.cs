using System.Collections.Generic;
using System;

namespace CalcEngine
{
    public abstract class Evaluator
    {
        public Evaluator()
        {
        }

        public virtual object Evaluate(IEnumerable<INode> nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));

            var nodesList = new LinkedList<INode>(nodes);

            object result = 0;
            foreach (var node in nodesList)
                EvaluateNode(nodesList.Find(node), ref result);
            return result;
        }

        public abstract void EvaluateNode(LinkedListNode<INode> current, ref object result);

    }
}