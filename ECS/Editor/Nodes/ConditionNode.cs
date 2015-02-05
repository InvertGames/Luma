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
        [VariableProperty]
        public string A { get; set; }

        [NodeProperty]
        public ComparisonType ComparisonType { get; set; }

        [JsonProperty, NodeProperty]
        public string B { get; set; }

        public string Sign
        {
            get
            {
                switch (ComparisonType)
                {
                        case ComparisonType.NotEqual:
                        return "!=";
                    case ComparisonType.Equal:
                        return "==";
                        case ComparisonType.GreaterThan:
                        return ">";
                        case ComparisonType.GreaterThanOrEqualTo:
                        return ">=";
                        case ComparisonType.LessThan:
                        return "<";
                        default:
                        return "<=";
                        
                }
            }
        }
        public override string Name
        {
            get
            {
                if (A == null || B == null)
                {
                    return "Condition";
                }
                return string.Format("{0} {1} {2}", A, Sign, B);
            }
            set { base.Name = value; }
        }


        public override void WriteCode(TemplateContext ctx)
        {
            
            ctx.PushStatements(ctx._if(string.Format("{0} {1} {2}", A, Sign, B)).TrueStatements);
            base.WriteCode(ctx);
            ctx.PopStatements();

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
