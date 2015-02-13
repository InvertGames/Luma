using Invert.Json;

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ComponentNode : ComponentNodeBase, IClassTypeNode {
        private ComponentPropertyChildItem _entityIdChildItem;
        private string _entityIdGuid;

        public bool Saveable
        {
            get { return this["Saveable"]; }
            set { this["Saveable"] = value; }
        }

        public string ClassName
        {
            get { return Name; }
        }
      
        public string EntityIdGuid
        {
            get { return string.IsNullOrEmpty(_entityIdGuid) ? (_entityIdGuid = Guid.NewGuid().ToString()) : _entityIdGuid; }
            set { _entityIdGuid = value; }
        }

        public ComponentPropertyChildItem EntityIdChildItem
        {
            get { return _entityIdChildItem ?? (_entityIdChildItem = new ComponentPropertyChildItem()
            {
                Identifier = EntityIdGuid,
                Node = this,
                Name = "EntityId",
                RelatedType = "ENTITY",
                Precompiled = true,
            }); }
            set { _entityIdChildItem = value; }
        }

        public override IEnumerable<IDiagramNodeItem> PersistedItems
        {
            get { return base.PersistedItems.Concat(new[] { EntityIdChildItem }); }
            set
            {
                base.PersistedItems = value;
                
            }
        }

        [Invert.Core.GraphDesigner.Section("Properties", SectionVisibility.Always, OrderIndex=0)]
        public override System.Collections.Generic.IEnumerable<ComponentPropertyChildItem> Properties {
            get
            {
                foreach (var item in PersistedItems.OfType<ComponentPropertyChildItem>())
                {
                    yield return item;
                }
            }
        }

        public override void Serialize(JSONClass cls)
        {
            base.Serialize(cls);
            cls.Add("EntityIdGuid", new JSONData(EntityIdGuid));
        }
         
        public override void Deserialize(JSONClass cls, INodeRepository repository)
        {
            base.Deserialize(cls, repository);
            if (cls["EntityIdGuid"] != null)
            {
                EntityIdGuid = cls["EntityIdGuid"].Value;
                EntityIdChildItem.Identifier = EntityIdGuid;
            }
        }

        public ComponentNode()
        {

        }
    }
}
