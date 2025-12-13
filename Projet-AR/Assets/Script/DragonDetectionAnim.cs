using UnityEngine;
using Vuforia;
using System.Collections;

public class DragonDetectionAnim : MonoBehaviour
{

    //Permet de lancer une animation quand le dragon est détecté par la caméra Vuforia
    public VuforiaObject dragonTarget;

    public VuforiaObject chevalierTarget;

    public VuforiaObject archerTarget;
    public VuforiaObject AttackTarget;
    public Animator anim;
    private bool hasScreamed = false;
    private bool archerDead = false;
    public Animator archerAnimator;
    public AudioSource dragonAnimator;

    public AudioSource feudragon;
    public Animator chevalierAnimator;
    private bool hasTakenOff = false;
    public GameObject boutton;
    public static bool buttonShown = false;
    public GameObject Fin;


    void Start()
    {
        buttonShown = false;
        hasTakenOff = false;
        boutton.SetActive(false);
        Fin.SetActive(false);
    }
    void Update()
    {
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

        if (dragonTarget.isDetected && archerTarget.isDetected && !hasScreamed && chevalierTarget.isDetected)
        {
            
           
            dragonAnimator.volume = 1f;
            if (!dragonAnimator.isPlaying) //  évite de relancer le son
                dragonAnimator.Play();    // Joue le son du dragon
            anim.SetTrigger("Scream");  // Déclenche l'animation Scream
            hasScreamed = true;         // Empêche de relancer tant que le dragon reste visible
            
        }


        if ((dragonTarget.isDetected && archerTarget.isDetected && chevalierTarget.isDetected && hasScreamed==true))
        if (state.IsName("Idle02"))
        {
             Timerscript.timerActive = true;
           boutton.SetActive(true);
            buttonShown = true; // empêche de le réactiver en boucle
        }
        //else if (!dragonTarget.isDetected)
        //{
        //    hasScreamed = false;        // Reset si le dragon disparaît


        //}

        

            if (state.IsName("Fly Flame Attack"))
        {
            // Action à faire quand l'anim est en cours
            
            StartCoroutine(Feustop());
            StartCoroutine(Mort());
            
        }

                if (Timerscript.fintimer == true && !hasTakenOff)
        {
            anim.SetTrigger("Feu2");
            hasTakenOff = true; // empêche de relancer chaque frame
            StartCoroutine(FIN());
        }


        if (state.IsName("Fly Flame Attack 0"))
        {
            StartCoroutine(Feustop());

            StartCoroutine(Mort2());
        }
        

        if (Timerscript.fintimer == true)
        {
            boutton.SetActive(false);
        }
        if (GreetingManager.attack == true)
        {
            anim.SetTrigger("Die");
        }

    }

    IEnumerator FIN()
    {
        yield return new WaitForSeconds(8.0f);
        Fin.SetActive(true);
        
    }

    IEnumerator Feustop()
    {
        if (!feudragon.isPlaying)
            feudragon.Play();
        yield return new WaitForSeconds(3.0f);
        feudragon.Stop();

    }
    IEnumerator Mort()
    {

        yield return new WaitForSeconds(1.0f);
        archerAnimator.SetTrigger("Mort");
        archerDead = true;
    }
    
    IEnumerator Mort2()
    {

        yield return new WaitForSeconds(1.0f);
        chevalierAnimator.SetTrigger("Mort");
       
    }
    
}
