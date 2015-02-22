// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class SystemsNodeViewModelBase : Invert.Core.GraphDesigner.GenericNodeViewModel<SystemsNode> {
        
        public SystemsNodeViewModelBase(SystemsNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class SystemNodeViewModelBase : Invert.Core.GraphDesigner.GenericNodeViewModel<SystemNode> {
        
        public SystemNodeViewModelBase(SystemNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class ComponentNodeViewModelBase : Invert.Core.GraphDesigner.GenericNodeViewModel<ComponentNode> {
        
        public ComponentNodeViewModelBase(ComponentNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class EventNodeViewModelBase : Invert.Core.GraphDesigner.GenericNodeViewModel<EventNode> {
        
        public EventNodeViewModelBase(EventNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class EventHandlerNodeViewModelBase : ActionNodeViewModel {
        
        public EventHandlerNodeViewModelBase(EventHandlerNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class ActionNodeViewModelBase : Invert.Core.GraphDesigner.GenericNodeViewModel<ActionNode> {
        
        public ActionNodeViewModelBase(ActionNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class SimpleClassNodeViewModelBase : Invert.Core.GraphDesigner.GenericNodeViewModel<SimpleClassNode> {
        
        public SimpleClassNodeViewModelBase(SimpleClassNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class SendSignalNodeViewModelBase : ActionNodeViewModel {
        
        public SendSignalNodeViewModelBase(SendSignalNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class ConditionNodeViewModelBase : ActionNodeViewModel {
        
        public ConditionNodeViewModelBase(ConditionNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class VariableNodeViewModelBase : Invert.Core.GraphDesigner.GenericNodeViewModel<VariableNode> {
        
        public VariableNodeViewModelBase(VariableNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class EqualNodeViewModelBase : ConditionNodeViewModel {
        
        public EqualNodeViewModelBase(EqualNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
    
    public class LoopNodeViewModelBase : ActionNodeViewModel {
        
        public LoopNodeViewModelBase(LoopNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
}
