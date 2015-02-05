using System.CodeDom;

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class EventHandlerEntityMappingReference : EventHandlerEntityMappingReferenceBase, ITypedItem{

        

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
            set {  }
        }

        public string RelatedTypeName
        {
            get
            {
                var relatedType = RelatedType;
                if (RelatedType == null)
                {
                    var outputTo = this.OutputTo<ComponentNode>();
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

    }
    
    public partial interface IEventHandlerEntityMapping : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
        
    }

    public partial interface IEntityEventHandlerMapping : IEventHandlerEntityMapping
    {
        bool IsEntity { get; }
    }
}
