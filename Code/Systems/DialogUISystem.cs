using UnityEngine;
using UnityEngine.UI;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using FlipCube;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class DialogUISystem : DialogUISystemBase {
        private DialogUI _dialogUi;

        public DialogUI DialogUI
        {
            get { return _dialogUi ?? (_dialogUi = DialogUIManager.Components.FirstOrDefault()); }
            set { _dialogUi = value; }
        }

        protected override void OnDialogCreated(Dialog data, Dialog @group)
        {
            base.OnDialogCreated(data, data);
            DialogUI.DialogQueue.Add(data);
        }

        protected override void OnDialogUICreated(DialogUI data, DialogUI @group)
        {
            base.OnDialogUICreated(data, @group);
            data.UIContainer.SetActive(false);
        }

        protected override void OnDialogAddedToQueue(DialogUI data, DialogUI @group, Dialog item)
        {
            base.OnDialogAddedToQueue(data, @group, item);
            ShowDialog(item);
        }

        protected override void OnDialogRemovedFromQueue(DialogUI data, DialogUI @group, Dialog item)
        {
            base.OnDialogRemovedFromQueue(data, @group, item);
            var nextDialog = data.DialogQueue.LastOrDefault();
            if(nextDialog != null) ShowDialog(nextDialog);
            else DialogUI.UIContainer.SetActive(false);
        }

        private void ShowDialog(Dialog dialog)
        {
            DialogUI.UIContainer.SetActive(true);
            for (int i = 0; i < DialogUI.ButtonsContainer.childCount; i++)
            {
                var child = DialogUI.ButtonsContainer.GetChild(i);
                Destroy(child.gameObject);
            }

            DialogUI.Message.text = dialog.Message;
            DialogUI.Header.text = dialog.Header;

            foreach (var dialogAction in dialog.Actions)
            {
                var buttonObject = Instantiate(dialog.gameObject);
                buttonObject.transform.localScale = Vector3.one;
                buttonObject.transform.SetParent(DialogUI.ButtonsContainer);
                buttonObject.GetComponentInChildren<Text>().text = dialogAction.Title;
                var button = buttonObject.GetComponent<Button>();
                button.onClick.AddListener(() =>
                {
                    dialogAction.Action();
                    DialogUI.DialogQueue.Remove(dialog);
                    Destroy(dialog);
                });
            }

        }
    }


    public class DialogAction
    {
        public Action Action { get; set; }
        public string Title { get; set; }
    }
}
