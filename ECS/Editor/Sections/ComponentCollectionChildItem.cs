namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class ComponentCollectionChildItem : ComponentCollectionChildItemBase, IEntityEventHandlerMapping
    {
        public override string DefaultTypeName
        {
            get { return typeof(int).Name; }
        }

        public bool IsEntity
        {
            get { return RelatedType == "ENTITY"; }
        }
        public override string RelatedTypeName
        {
            get
            {
                if (RelatedType == "ENTITY")
                    return typeof(Int32).Name + "";
                return base.RelatedTypeName;
            }
        }
    }
    public class ComponentCollectionChildViewModel : TypedItemViewModel
    {
        public ComponentCollectionChildViewModel(ComponentCollectionChildItem viewModelItem, DiagramNodeViewModel nodeViewModel)
            : base(viewModelItem, nodeViewModel)
        {
        }

        public override string RelatedType
        {
            get
            {
                if (Data.RelatedType == "ENTITY")
                    return "ENTITY[]";
                return base.RelatedType;
            }
            set { base.RelatedType = value; }
        }
    }

    public class ComponentCollectionDrawer : TypedItemDrawer
    {
        public ComponentCollectionDrawer(ComponentCollectionChildViewModel viewModel)
            : base(viewModel)
        {
        }
    }
}
