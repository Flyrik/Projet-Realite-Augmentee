using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class GreetingManager : MonoBehaviour
{
    public VuforiaObject target1;
    public VuforiaObject target2;

    public VuforiaObject dragonTarget;
    public VuforiaObject AttackTarget;
    public static bool tempsstop = false;

    public GameObject victoire;

    public List<Animator> animators; // liste de tous les persos
    public float greetDistance = 0.2f;

    private bool greeted = false;

    public static bool attack = false;

    void Start()
    {
        tempsstop = false;
        attack = false;
    }

    void Update()
    {
        if (target1.isDetected && target2.isDetected)
        {
            float dist = Vector3.Distance(target1.transform.position, target2.transform.position);

            if (dist < greetDistance && !greeted)
            {
                if (dragonTarget.isDetected)
                {

                }
                else
                {
                    foreach (Animator anim in animators)
                    {
                        anim.SetTrigger("Greet");
                    }

                }




                greeted = true;
                StartCoroutine(ResetGreet());
            }
        }

        if (target1.isDetected && target2.isDetected && dragonTarget.isDetected && AttackTarget.isDetected && DragonDetectionAnim.buttonShown==true)
        {
            Attack();
            Debug.Log("GO");
            StartCoroutine(Victory());
            HealthManager.instance.TakeDamageDragon(300f);
        }


    }

   
    IEnumerator ResetGreet()
    {
        yield return new WaitForSeconds(4f);

        
        greeted = false;
    }

    public void Attack()

    {
        attack = true;
        Vector3 direction = dragonTarget.transform.position - animators[0].transform.position;
        direction.y = 0; 

        // Rotation vers le dragon
        animators[0].transform.rotation = Quaternion.LookRotation(direction);

        // Lance l'attaque
        animators[0].SetTrigger("Attack");
        tempsstop = true;
    }
    IEnumerator Victory()
    {
        yield return new WaitForSeconds(5f);
        victoire.SetActive(true);
    }
}
