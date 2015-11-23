using UnityEngine;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    using UniRx;
    
    
    public partial class UIWidgetSystem {
        protected override void ExecuteChangeCompositeWidgetStateHandler(ChangeWidgetStateDispatcher data, CompositeUIWidget source)
        {
            base.ExecuteChangeCompositeWidgetStateHandler(data, source);
            source.UIWidget.State = data.State;
        }

        protected override void ExecuteChangeSingularWidgetStateHandler(ChangeWidgetStateDispatcher data, SingularUIWidget source)
        {
            base.ExecuteChangeSingularWidgetStateHandler(data, source);
            source.UIWidget.State = data.State;
        }

        protected override void CompositeWidgetIsActiveChanged(CompositeUIWidget data, CompositeUIWidget @group, PropertyChangedEvent<bool> value)
        {
            base.CompositeWidgetIsActiveChanged(data, @group, value);
            var active = value.CurrentValue;
            if (active)
            {
                SetAnimatorIsActive(data.Animated.Animator, value.CurrentValue);
            }
            else
            {
                var allChildrenHidden = @group.Composite.Widgets.All(w => w.State == WidgetState.Hidden);
                if (allChildrenHidden)
                {
                    SetAnimatorIsActive(data.Animated.Animator, value.CurrentValue);
                }
                else
                {
                    foreach (var uiWidget in @group.Composite.Widgets)
                    {
                        uiWidget.IsActive = false;
                    }
                }
            }
        }

        void SetAnimatorIsActive(Animator animator, bool value)
        {
            if (animator != null && animator.isInitialized)
            {
                animator.SetBool("IsActive", value);
            }
        }

        protected override void SingularWidgetIsActiveChanged(SingularUIWidget data, SingularUIWidget @group, PropertyChangedEvent<bool> value)
        {
            base.SingularWidgetIsActiveChanged(data, @group, value);
            SetAnimatorIsActive(data.Animated.Animator,value.CurrentValue);
        
        }

        protected override void OnUIWidgetStateChanged(UIWidget data, UIWidget @group, PropertyChangedEvent<WidgetState> value)
        {
            base.OnUIWidgetStateChanged(data, @group, value);

            if (data.State != WidgetState.Hidden) return;
            var parent = CompositeUIWidgetManager.Components.FirstOrDefault(w => w.Composite.Widgets.Contains(data));
            if (parent != null && !parent.UIWidget.IsActive)
            {
                var allChildrenHidden = parent.Composite.Widgets.All(w => w.State == WidgetState.Hidden);
                if(allChildrenHidden) SetAnimatorIsActive(parent.Animated.Animator,false);
            }

        }
    }
}
