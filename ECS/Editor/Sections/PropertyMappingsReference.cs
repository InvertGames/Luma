using Invert.Json;
using UnityEngine;

namespace Invert.ECS.Graphs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;


    public class PropertyMappingsReference : PropertyMappingsReferenceBase
    {
        [JsonProperty, NodeProperty]
        public string Expression { get; set; }

        public override void Validate(List<ErrorInfo> info)
        {
            base.Validate(info);
            var actionNode = Node as ActionNode;
            if (actionNode != null)
            {
                var contextVariable = actionNode.AllContextVariables.FirstOrDefault(p => p.VariableName == Expression);
                if (contextVariable == null)
                {
                    info.AddError("Variable not found", this.Node.Identifier, () =>
                    {
                        Node.Project.RemoveItem(this);
                    });
                }
            }

        }

        //public override void Serialize(JSONClass cls)
        //{
        //    base.Serialize(cls);
        //    if (Ids != null)
        //    cls.Add("Ids", new JSONData(string.Join("." , Ids)));
        //}

        //public override void Deserialize(JSONClass cls, INodeRepository repository)
        //{
        //    base.Deserialize(cls, repository);
        //    if (cls["Ids"] != null)
        //    {
        //        Ids = cls["Ids"].Value.Split('.');
        //    }
        //}
    }

    public partial interface IPropertyMappings : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable
    {
    }

    public class PropertyMappingsReferenceViewModel : ItemViewModel<PropertyMappingsReference>
    {
        public PropertyMappingsReferenceViewModel(PropertyMappingsReference viewModelItem, DiagramNodeViewModel nodeViewModel)
            : base(viewModelItem, nodeViewModel)
        {
        }

    }

    public class PropertyMappingsReferenceDrawer : ItemDrawer<PropertyMappingsReferenceViewModel>
    {
        public PropertyMappingsReferenceDrawer(PropertyMappingsReferenceViewModel viewModel)
            : base(viewModel)
        {
            
        }
        private Vector2 _typeSize;
        private string _cachedTypeName;
        private string _cachedItemName;
        private Vector2 _nameSize;

        public override void Refresh(IPlatformDrawer platform, Vector2 position, bool hardRefresh = true)
        {
            base.Refresh(platform, position, hardRefresh);
            if (!hardRefresh)
            {
                
            }
            _cachedTypeName = ViewModel.Data.Expression ?? "Select";
            _cachedItemName = ViewModel.Name;
            _nameSize = platform.CalculateSize(_cachedItemName, TextStyle);
            _typeSize = platform.CalculateSize(_cachedTypeName, TextStyle);

            Bounds = new Rect(position.x, position.y, _nameSize.x + 5 + _typeSize.x + 40, 18);
        }

        public override void Draw(IPlatformDrawer platform, float scale)
        {
            var b = new Rect(Bounds);
            b.x += 10;
            b.width -= 20;
            //base.Draw(platform, scale);
            platform.DrawColumns(b.Scale(scale),new [] { _typeSize.x + 5, _nameSize.x },
            _ =>
            {
                platform.DrawLabel(_, _cachedItemName, CachedStyles.ClearItemStyle);
            },
                _ =>
                {
                    platform.DoButton(_, _cachedTypeName, CachedStyles.ItemTextEditingStyle, () =>
                    {
                        var node = this.ViewModel.NodeViewModel.DataObject as ActionNode;
                        if (node != null)
                        {
                            InvertGraphEditor.WindowManager.InitItemWindow(node.AllContextVariables, (item) =>
                            {
                                this.ViewModel.Data.Expression = item.VariableName;
                            });
                        }

                    });
                }
            );

        }
    }
}
