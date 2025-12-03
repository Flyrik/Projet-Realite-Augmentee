using UnityEngine;
using TMPro;

public class Quetescritp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public VuforiaObject chevalier;
    public VuforiaObject archer;
    public VuforiaObject Rage;
    public TextMeshProUGUI quetes1grogu;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chevalier.isDetected == true)
        {
            quetes1grogu.text = "Afficher";
            quetes1grogu.color = Color.green;

        }
        else
        {
            quetes1grogu.text = "Non Afficher";
            quetes1grogu.color = Color.red;



        }
    }

}