using Invert.ECS;
using Invert.ECS.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventDispatcher : MonoBehaviour
{
    public Button _Button;

    public void Awake()
    {
        if (_Button == null)
        {
            _Button = GetComponent<Button>();
            if (_Button == null)
                return;
        }
        _Button.onClick.AddListener(() =>
        {
            UnityGame.Instance.EventManager.SignalEvent(new EventData()
            {
                EventType = uGUIEvents.Click,
                Data = new UIEventData()
                {
                    EntityId = GetComponent<EntityComponent>().EntityId,
                    Component = _Button,
                    Name = _Button.name
                }
            });
        });
    }
    

}