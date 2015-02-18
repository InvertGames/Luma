using System.CodeDom;
using System.Security.Cryptography.X509Certificates;
using Invert.Core;

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;

    public interface IContextVariable : IItem
    {
        //IEnumerable<IContextVariable> Members { get; }
        ITypedItem SourceVariable { get; set; }
        string VariableName { get; set; }
    }

    public interface IVariableExpressionItem
    {
        string Expression { get; set; }
    }
    public class ContextVariable : IContextVariable
    {
        private string _memberExpression;

        public ContextVariable(params object[] items )
        {
            Items = items;
        }

        public object[] Items { get; set; }

        public string MemberExpression
        {
            get { return _memberExpression ?? (_memberExpression = string.Join(".", Items.Select(p =>
            {
                var cv = p as IDiagramNodeItem;
                if (cv != null) return cv.Name;
                return (string) p;
            }).ToArray())); }
        }

        public string Title
        {
            get { return MemberExpression; }
        }

        public string Group
        {
            get
            {
                if (Items.Length < 1)
                    return "Missing";

                var item = Items.Length > 1 ? Items[Items.Length - 2] : Items.Last();
                var cv = item as IDiagramNodeItem;
                if (cv != null)
                {
                    return cv.Name;
                }
                return (string)item;
            }
        }

        public string SearchTag
        {
            get { return MemberExpression; }
        }

        public string VariableName
        {
            get { return MemberExpression; }
            set { }
        }

        public ITypedItem SourceVariable { get; set; }
    }
    public class ComponentPropertyChildItem : ComponentPropertyChildItemBase,  IEntityEventHandlerMapping
    {
        private bool _save = false;

        [JsonProperty,InspectorProperty]
        public bool Saveable
        {
            get { return _save; }
            set { _save = value; }
        }

        private bool _playerStat;

        [JsonProperty, InspectorProperty]
        public bool PlayerStat
        {
            get { return _playerStat; }
            set
            {
                _playerStat = value;
                if (value == true)
                {
                    Saveable = true;
                }
            }
        }
        public override string DefaultTypeName
        {
            get { return typeof (int).Name; }
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
                    return typeof (Int32).Name;
                return base.RelatedTypeName;
            }
        }


        public IEnumerable<IContextVariable> Members
        {
            get
            {
                var relatedTypeNode = RelatedTypeNode;
                if (RelatedTypeNode != null)
                {
                    foreach (var item in relatedTypeNode.PersistedItems.OfType<IContextVariable>())
                    {
                        yield return item;
                        
                    }
                }
            }
        }

        public CodeExpression MemberExpresion()
        {
            return new CodeSnippetExpression(this.Name);
        }

        public string VariableName
        {
            get { return this.Name; }
        }
    }

    public class ComponentPropertyChildViewModel : TypedItemViewModel
    {
        public ComponentPropertyChildViewModel(ComponentPropertyChildItem viewModelItem, DiagramNodeViewModel nodeViewModel)
            : base(viewModelItem, nodeViewModel)
        {
        }

        public ComponentPropertyChildItem PropertyData
        {
            get { return (ComponentPropertyChildItem) DataObject; }
        }

        public bool IsSaveable
        {
            get { return PropertyData.Saveable; }
        }

        public override string RelatedType
        {
            get
            {
                if (Data.RelatedType == "ENTITY")
                    return "ENTITY";
                return base.RelatedType;
            }
            set { base.RelatedType = value; }
        }

        public bool IsStat
        {
            get { return PropertyData.PlayerStat; }
        }
    }

    public class ComponentPropertyDrawer : TypedItemDrawer
    {
        public ComponentPropertyDrawer(ComponentPropertyChildViewModel viewModel)
            : base(viewModel)
        {
        }

        public ComponentPropertyChildViewModel PropertyViewModel
        {
            get { return ViewModelObject as ComponentPropertyChildViewModel; }

        }
        public override void DrawBackground(IPlatformDrawer platform, float scale)
        {
            if (ViewModelObject.IsSelected)
            {
                base.DrawBackground(platform, scale);
            }
            else if (PropertyViewModel.IsStat)
            {
                platform.DrawStretchBox(Bounds.Scale(scale), CachedStyles.Item1, 0f);
            }
            else if (PropertyViewModel.IsSaveable)
            {
                platform.DrawStretchBox(Bounds.Scale(scale), CachedStyles.Item2, 0f);
            }
            

        }

        public override void Draw(IPlatformDrawer platform, float scale)
        {
            base.Draw(platform, scale);
        }
    }
}
