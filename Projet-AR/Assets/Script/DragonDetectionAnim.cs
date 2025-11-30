using UnityEngine;
using Vuforia;

public class DragonDetectionAnim : MonoBehaviour
{
    
    //Permet de lancer une animation quand le dragon est détecté par la caméra Vuforia
    public VuforiaObject dragonTarget; 

    public VuforiaObject chevalierTarget;
    public Animator anim;             
    private bool hasScreamed = false;  

    public AudioSource dragonAnimator;
    void Update()
    {
        if (dragonTarget.isDetected && chevalierTarget.isDetected && !hasScreamed)
        {
            dragonAnimator.volume = 0.1f;
            dragonAnimator.Play();      // Joue le son du dragon
            anim.SetTrigger("Scream");  // Déclenche l'animation Scream
            hasScreamed = true;         // Empêche de relancer tant que le dragon reste visible
        }
        //else if (!dragonTarget.isDetected)
        //{
        //    hasScreamed = false;        // Reset si le dragon disparaît
        //}
    }
}
