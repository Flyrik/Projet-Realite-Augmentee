using UnityEngine;
using Vuforia;

public class ImageTargetChecker : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    private bool isDetected = false;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        else
        {
            Debug.LogError("Pas de ObserverBehaviour attaché !");
        }
    }

    // Cette fonction est appelée automatiquement par Vuforia
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        isDetected = (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED);
    }

    void Update()
    {
        // Vérifie en boucle si l'image est détectée
        if (isDetected)
        {
            Debug.Log("Image target détectée ! (en boucle)");
        }
        else
        {
            Debug.Log("Image target perdue... (en boucle)");
        }
    }

    private void OnDestroy()
    {
        if (observerBehaviour)
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
    }
}
