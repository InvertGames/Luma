using System.CodeDom;

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ActionNode : ActionNodeBase, ICodeOutput {
        public ActionNode Left
        {
            get { return this.InputFrom<ActionNode>(); }
        }

        public IEnumerable<ActionNode> LeftNodes
        {
            get
            {
                var left = Left;
                while (left != null)
                {
                    yield return left;
                    left = left.Left;
                }
            }
        }
        public IEnumerable<ActionNode> RightNodes
        {
            get
            {
                var right = Right;
                while (right != null)
                {
                    yield return right;
                    right = right.Right;
                }
            }
        }
        public ActionNode Right
        {
            get { return this.OutputTo<ActionNode>(); }
        }

        public IEnumerable<IContextVariable> AllContextVariables
        {
            get
            {
                var left = Left;
                if (left != null)
                {
                    foreach (var contextVar in left.AllContextVariables)
                    {
                        yield return contextVar;
                    }
                }
                foreach (var item in ContextVariables)
                {
                    yield return item;
                }
            }
        }

        public virtual IEnumerable<IContextVariable> ContextVariables
        {
            get { yield break; }
        }

        public virtual void WriteCode(TemplateContext ctx)
        {
            var right = Right;
            if (right != null)
            {
                right.WriteCode(ctx);
            }
        }
    }

    public interface ICodeOutput
    {
        IEnumerable<IContextVariable> AllContextVariables { get; }
        IEnumerable<IContextVariable> ContextVariables { get; }
        
        void WriteCode(TemplateContext ctx);
    }

    public class VariableSlotAttribute : Attribute
    {
        public string Name { get; set; }
        
        public Type ViewModelType { get; set; }
        
    }

    public class MappingSlotAttribute : Attribute
    {
        
    }
    
}
