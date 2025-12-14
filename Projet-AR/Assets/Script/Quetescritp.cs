using UnityEngine;
using TMPro;
using System.Collections;

public class Quetescritp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public VuforiaObject chevalier;
    public VuforiaObject archer;
    public VuforiaObject Rage;

    public VuforiaObject dragon;
    public VuforiaObject AttackTarget;
    public TextMeshProUGUI quetes1grogu;
    public AudioSource recompense;

    public TextMeshProUGUI quete2Text;

    public TextMeshProUGUI quete3Text;
    public TextMeshProUGUI quete4Text;
    public TextMeshProUGUI quete5Text;
    

    private bool quete1Done = false;
    private bool quete2Done = false;

    private bool quete3Done = false;

    private bool quete4Done = false;

    private bool quete5Done = false;


    public GameObject QueteOBJ1;
    public GameObject QueteOBJ2;
    public GameObject QueteOBJ3;
    public GameObject QueteOBJ4;
    public GameObject QueteOBJ5;


    void Start()
    {
        quete2Done = false;
        quete1Done = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (!quete1Done) // elle n’est PAS encore faite
        {
            if (chevalier.isDetected == true)
            {
                quete1Done = true;
                quetes1grogu.text = "Afficher";
                quetes1grogu.color = Color.green;
                PointManager.instance.AddScore(20);
                StartCoroutine(Attendre());
                recompense.Play();
                
                

            }
            else
            {
                quetes1grogu.text = "Non Afficher";
                quetes1grogu.color = Color.red;



            }
        }
         if (quete1Done && !quete2Done)  // La quête 2 ne commence que si la 1 est faite
        {
            if (archer.isDetected && chevalier.isDetected)
            {
                quete2Done = true;
                quete2Text.text = "Afficher";
                quete2Text.color = Color.green;
                PointManager.instance.AddScore(30);
                StartCoroutine(Attendre2());
                recompense.Play();
                
                return;
            }
            else
            {
                quete2Text.text = "Non Afficher";
                quete2Text.color = Color.red;
            }

        }
        if (quete1Done && quete2Done && !quete3Done)
        {
            if (Rage.isDetected && chevalier.isDetected)
            {
                quete3Done = true;
                quete3Text.text = "Afficher";
                quete3Text.color = Color.green;
                PointManager.instance.AddScore(10);
                StartCoroutine(Attendre3());
                //recompense.Play();
                return;
            }
            else
            {
                quete3Text.text = "Non Afficher";
                quete3Text.color = Color.red;
            }

        }
        if (quete1Done && quete2Done && quete3Done && !quete4Done)
        {
            if (dragon.isDetected && archer.isDetected && chevalier.isDetected)
            {
                quete4Done = true;
                quete4Text.text = "Afficher";
                quete4Text.color = Color.green;
                PointManager.instance.AddScore(50);
                StartCoroutine(Attendre4());
                //recompense.Play();
                return;
            }
            else
            {
                quete4Text.text = "Non Afficher";
                quete4Text.color = Color.red;
            }

        }
        if (quete1Done && quete2Done && quete3Done && quete4Done && DragonDetectionAnim.buttonShown==true  && !quete5Done)
        {
            if (chevalier.isDetected && archer.isDetected && dragon.isDetected && AttackTarget.isDetected)
            {
                quete5Text.text = "Afficher";
                quete5Text.color = Color.green;
                PointManager.instance.AddScore(90);
                recompense.Play();
                 quete5Done = true;
                return;
            }
            else
            {
                quete5Text.text = "Non Afficher";
                quete5Text.color = Color.red;
            }

        }
    }
    IEnumerator Attendre()
{
    yield return new WaitForSeconds(2);
    QueteOBJ1.SetActive(false);
            QueteOBJ2.SetActive(true);
}

IEnumerator Attendre2()
{
    yield return new WaitForSeconds(2);
    QueteOBJ2.SetActive(false);
            QueteOBJ3.SetActive(true);
}

IEnumerator Attendre3()
{
    yield return new WaitForSeconds(2);
    QueteOBJ3.SetActive(false);
            QueteOBJ4.SetActive(true);
}

IEnumerator Attendre4()
{
    yield return new WaitForSeconds(14);
    QueteOBJ4.SetActive(false);
        QueteOBJ5.SetActive(true);
}

}