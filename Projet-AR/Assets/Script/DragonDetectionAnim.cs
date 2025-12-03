using UnityEngine;
using Vuforia;
using System.Collections;

public class DragonDetectionAnim : MonoBehaviour
{

    //Permet de lancer une animation quand le dragon est détecté par la caméra Vuforia
    public VuforiaObject dragonTarget;

    public VuforiaObject chevalierTarget;

    public VuforiaObject archerTarget;
    public Animator anim;
    private bool hasScreamed = false;
    private bool archerDead = false;
    public Animator archerAnimator;
    public AudioSource dragonAnimator;
    void Update()
    {
        if (dragonTarget.isDetected && archerTarget.isDetected && !hasScreamed && chevalierTarget.isDetected)
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
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Fly Flame Attack"))
        {
            // Action à faire quand l'anim est en cours
            StartCoroutine(Mort());
        }

    }

    IEnumerator Mort()
    {

        yield return new WaitForSeconds(1.0f);
            archerAnimator.SetTrigger("Mort");
            archerDead = true; // Empêche de relancer la mort
            Debug.Log("Archer est mort !");
    }
}
