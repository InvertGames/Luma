using System.CodeDom;
using UnityEngine;

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SendSignalNode : SendSignalNodeBase {
        public override string Name
        {
            get
            {
                var evt = Event;
                if (evt != null)
                {
                    return evt.Name;
                }
                return "Send Signal";
            }
            set { base.Name = value; }
        }
        
        [JsonProperty]
        public string EventTypeId { get; set; }

        [ NodeProperty(InspectorType.GraphItems)]
        public EventsChildItem Event
        {
            get { return Project.NodeItems.OfType<SystemNode>().SelectMany(p=>p.Events).FirstOrDefault(p => p.Identifier == EventTypeId) as EventsChildItem; }
            set
            {

                if (value != null)
                    EventTypeId = value.Identifier;
            }
        }
        [Invert.Core.GraphDesigner.ReferenceSection("Parameters", SectionVisibility.Always, false, false, typeof(IPropertyMapsConnectable), false, OrderIndex = 0, HasPredefinedOptions = false)]
        public override System.Collections.Generic.IEnumerable<PropertyMapsReference> PropertyMaps
        {
            get
            {
                return ChildItems.OfType<PropertyMapsReference>();
            }
        }
        public override IEnumerable<IPropertyMapsConnectable> PossiblePropertyMaps
        {
            get
            {
                var evt = Event;
                if (evt == null) yield break;
                var relatedTypeNode = evt.RelatedTypeNode as EventNode;
                if (relatedTypeNode == null) yield break;
                foreach (var item in relatedTypeNode.Properties)
                {
                    yield return item;
                }
            }
        }

        public override void WriteCode(TemplateContext ctx)
        {
          
            var variable = new CodeVariableDeclarationStatement(Event.RelatedTypeName, this.Name.ToLower() + "Data");
            variable.InitExpression = new CodeSnippetExpression(string.Format("new {0}()", Event.RelatedTypeName));
            ctx.CurrentStatements.Add(variable);

            foreach (var mapping in PropertyMaps)
            {

                var inputFrom = mapping;
                if (inputFrom == null) continue;
                var setter =
                    new CodeAssignStatement(
                        new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(variable.Name),
                            mapping.SourceItem.Name), new CodeSnippetExpression(mapping.Expression));

                ctx.CurrentStatements.Add(setter);

            }

            var methodInoke = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(Event.Node.Name), string.Format("Signal{0}", Event.Name));
            methodInoke.Parameters.Add(new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "Game"));
            methodInoke.Parameters.Add(new CodeVariableReferenceExpression(variable.Name));
            ctx.CurrentStatements.Add(methodInoke);
            base.WriteCode(ctx);
        }

    }
}
