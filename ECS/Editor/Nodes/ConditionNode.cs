using UnityEngine;

namespace Invert.ECS.Graphs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class ConditionNode : ConditionNodeBase
    {
        //[VariableProperty]
        //public string A { get; set; }

        //[NodeProperty]
        //public ComparisonType ComparisonType { get; set; }

        //[JsonProperty, NodeProperty]
        //public string B { get; set; }

        public VariableNode A
        {
            get { return AInputSlot.InputFrom<VariableNode>(); }
        }
        public VariableNode B
        {
            get { return BInputSlot.InputFrom<VariableNode>(); }
        }

        public virtual string Sign
        {
            get { return "=="; }
        }

        public override string Name
        {
            get
            {
                return this.GetType().Name.Replace("Node","");
                //if (A == null || B == null)
                //{
                   
                //}
                //return string.Format("{0} {1} {2}", A.Name, Sign, B.Name);
            }
            set { base.Name = value; }
        }


        public override void WriteCode(TemplateContext ctx)
        {
            var condition = ctx._if(string.Format("{0} {1} {2}", A, Sign, B));
            ctx.PushStatements(condition.TrueStatements);
            WriteTrueStatements(ctx);
            ctx.PopStatements();
            ctx.PushStatements(condition.FalseStatements);
            WriteFalseStatements(ctx);
            ctx.PopStatements();
            base.WriteCode(ctx);
        }

        protected virtual void WriteTrueStatements(TemplateContext ctx)
        {
            
        }

        protected virtual void WriteFalseStatements(TemplateContext ctx)
        {
            
        }
    }

    public enum ComparisonType
    {
        Equal,
        NotEqual,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
    }
    public class VariableProperty : JsonProperty
    {
        public string Name { get; set; }
    }
}
