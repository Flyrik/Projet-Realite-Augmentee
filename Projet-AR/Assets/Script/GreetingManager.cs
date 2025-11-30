using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
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
            
            foreach (Animator anim in animators)
            {
                anim.SetTrigger("Greet");
            }

           
            greeted = true;
            StartCoroutine(ResetGreet());
        }
    }
}

    IEnumerator ResetGreet()
    {
        yield return new WaitForSeconds(4f);

        
        greeted = false;
    }
}
