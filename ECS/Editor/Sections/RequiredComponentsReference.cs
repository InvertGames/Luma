using System.CodeDom;

namespace Invert.ECS.Graphs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class RequiredComponentsReference : RequiredComponentsReferenceBase, ITypedItem, IRequiredComponent
    {

        

        public string RelatedType
        {
            get
            {
                var sourceItem = SourceVariable as ITypedItem;
                if (sourceItem != null)
                {
                    return sourceItem.RelatedTypeName;
                }
                return null;
            }
            set { }
        }

        public ComponentNode Component
        {
            get
            {
                if (this.InputFrom<ComponentNode>() != null)
                    return this.InputFrom<ComponentNode>();
                var inputReference = this.InputFrom<ComponentsReference>();
                if (inputReference != null)
                {
                    return inputReference.SourceItem as ComponentNode;
                }
                return null;
            }
        }
        public string RelatedTypeName
        {
            get
            {
                var relatedType = RelatedType;
                if (RelatedType == null)
                {
                    var outputTo = this.Component;
                    if (outputTo == null)
                    {
                        return "int";
                    }
                    return outputTo.Name;
                }
                return relatedType;
            }
        }

        public ITypedItem SourceVariable
        {
            get { return SourceItem as ITypedItem; }
        }

        public bool IsEntity
        {
            get { return RelatedType == "ENTITY"; }
        }
    }

    public partial interface IRequiredComponentsConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable
    {
        //bool IsEntity { get; }
    }

    public interface IRequiredComponent : IRequiredComponentsConnectable
    {
        bool IsEntity { get; }
    }
}
