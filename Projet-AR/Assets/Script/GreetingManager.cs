using UnityEngine;
using System.Collections.Generic;

public class GreetingManager : MonoBehaviour
{
    public VuforiaObject target1;
    public VuforiaObject target2;
    

    public List<Animator> animators; // liste de tous les persos
    public float greetDistance = 0.2f;

    private bool greeted = false;

    void Update()
    {
        if (target1.isDetected && target2.isDetected)
        {
            float dist = Vector3.Distance(target1.transform.position, target2.transform.position);

            if (dist < greetDistance && !greeted)
            {
                // lance le Trigger sur tous les persos
                foreach (Animator anim in animators)
                {
                    anim.SetTrigger("Greet");
                }
                greeted = true;
            }
        }
        else
        {
            greeted = false; // reset si l’un disparaît
        }
    }
}
