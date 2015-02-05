using System.Reflection;
using Invert.Core;
using Invert.Core.GraphDesigner;
using UnityEngine;

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class ActionNodeViewModel : ActionNodeViewModelBase {
        
        public ActionNodeViewModel(ActionNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }

        public override NodeConfigBase NodeConfig
        {
            get
            {
                return _nodeConfig ?? (
                    _nodeConfig = InvertGraphEditor.Container.GetNodeConfig(DataObject.GetType()) as NodeConfigBase);
            }
        }

        protected override void CreateContent()
        {
           base.CreateContent();

            foreach (var item in this.DataObject.GetPropertiesWithAttribute<VariableProperty>())
            {
                var variableValue = item.Key.GetValue(DataObject, null);
                var variableDisplayValue = variableValue ?? "[None]";
                var item1 = item;
                ContentItems.Add(new ItemSelectionPropertyViewModel(this)
                {
                    DisplayValue = (string)variableDisplayValue,
                    Name = item.Value.Name ?? item.Key.Name,
                    Setter = (i) =>
                    {
                        item1.Key.SetValue(DataObject, i.Title,null);
                    },
                    Items=GraphItem.AllContextVariables.Cast<IItem>()
                });
            }

        }
    }

    public class ItemSelectionPropertyViewModel : GraphItemViewModel
    {
        
        public ItemSelectionPropertyViewModel(DiagramNodeViewModel nodeViewModel) : base()
        {

        }
        
        public override Vector2 Position { get; set; }
        public override string Name { get; set; }
        public string DisplayValue { get; set; }
        public IEnumerable<IItem> Items { get; set; }
        public Action<IItem> Setter { get; set; }

      
    }

    public class ItemSelectionPropertyDrawer : Drawer<ItemSelectionPropertyViewModel>
    {
  

        public ItemSelectionPropertyDrawer(ItemSelectionPropertyViewModel viewModelObject) : base(viewModelObject)
        {
        }
        private string _left;
        private string _right;
        private Vector2 _leftSize;
        private Vector2 _rightSize;
        public override void Refresh(IPlatformDrawer platform, Vector2 position, bool hardRefresh = true)
        {
            base.Refresh(platform, position, hardRefresh);
            if (hardRefresh)
            {
                _left = ViewModel.Name;
                _right = ViewModel.DisplayValue;
                _leftSize = platform.CalculateSize(_left, CachedStyles.ClearItemStyle);
                _rightSize = platform.CalculateSize(_right, CachedStyles.ItemTextEditingStyle);
            }


            Bounds = new Rect(position.x + 10, position.y, _leftSize.x + 5 + _rightSize.x + 40, 18);
        }
        public override void Draw(IPlatformDrawer platform, float scale)
        {
            base.Draw(platform, scale);
            platform.DrawColumns(this.Bounds.Scale(scale),new float[] {_leftSize.x + 10,_rightSize.x},
                _ => platform.DrawLabel(_,_left,CachedStyles.HeaderStyle),
                _ => platform.DoButton(_,_right,CachedStyles.HeaderStyle,SelectItem)
                );
        }

        private void SelectItem()
        {
            InvertGraphEditor.WindowManager.InitItemWindow(ViewModel.Items, ViewModel.Setter);
        }

    }
}
