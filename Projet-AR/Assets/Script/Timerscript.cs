 using UnityEngine;
using TMPro;

public class Timerscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float timeLimit = 20f;  // Durée en secondes
    private float timer;
    public static bool timerActive = false;
    

    public static bool fintimer = false;
    public TextMeshProUGUI timerText;
    void Start()
    {
        timer = timeLimit;
        fintimer = false;
        
    }



    // Update is called once per frame
    void Update()
{
    if (timerActive)
    {
        
        timerText.text = "Timer : " + timer.ToString("F1");
        timer -= Time.deltaTime;  // décompte en secondes

        if (timer <= 0f)
        {
            timerText.text = "Timer : " + "0.0";
            timerActive = false;
                fintimer = true;
            
        }
            if (GreetingManager.tempsstop == true)
            {
                timerActive = false;
            }
        }

}

    
 
}
