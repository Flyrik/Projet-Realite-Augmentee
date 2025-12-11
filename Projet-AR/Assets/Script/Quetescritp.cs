using UnityEngine;
using TMPro;
using System.Collections;

public class Quetescritp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public VuforiaObject chevalier;
    public VuforiaObject archer;
    public VuforiaObject Rage;
    public TextMeshProUGUI quetes1grogu;
    public AudioSource recompense;

    public TextMeshProUGUI quete2Text;

     private bool quete1Done = false;
    private bool quete2Done = false;

    private bool quete3Done = false;

    public GameObject QueteOBJ1;
    public GameObject QueteOBJ2;


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
            if (archer.isDetected & chevalier.isDetected)
            {
                quete2Done = true;
                quete2Text.text = "Afficher";
                quete2Text.color = Color.green;
                PointManager.instance.AddScore(30);

            }
            else
            {
                quete2Text.text = "Non Afficher";
                quete2Text.color = Color.red;
            }
        }
    }
    IEnumerator Attendre()
{
    yield return new WaitForSeconds(2);
    QueteOBJ1.SetActive(false);
                QueteOBJ2.SetActive(true);
}


}