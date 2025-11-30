using UnityEngine;
using Vuforia;


//Permet de savoir si un objet Vuforia est détecté ou non (pratique pcq on peut l'utilisér dans d'autres scripts en faisant "target.isDetected")
public class VuforiaObject : MonoBehaviour
{
    public bool isDetected = false;
    ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        observer.OnTargetStatusChanged += OnStatusChanged;
    }

    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        isDetected = (status.Status == Status.TRACKED 
                   || status.Status == Status.EXTENDED_TRACKED);
    }
}
