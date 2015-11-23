using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using UnityEngine.UI;
using UniRx;
public class KernelLoadingUI : MonoBehaviour {

    //Viewmodel
    public string Message;
    public float Progress;
    //View
    public Text MessageText;
    public Text PercentText;
    public Image Image;

    void Awake()
    {
        uFrameKernel.EventAggregator.GetEvent<ServiceLoaderEvent>().Subscribe(OnServiceLoaderEvent);
    }

    void OnServiceLoaderEvent(ServiceLoaderEvent evt)
    {
        if (evt.State == ServiceState.Loading)
        {
            Message = string.Format("Loading {0}", evt.Service.GetType().Name);
            Progress = evt.GlobalProgress;
            if (Progress >= 1f)
            {
                Destroy(gameObject);
            }
        }

    }


    void Update()
    {
        if (MessageText != null) MessageText.text = Message;
        if (Image != null) Image.fillAmount = Progress;
        if (PercentText != null) PercentText.text = string.Format("{0}%",(int)(Progress*100));
    }

}
