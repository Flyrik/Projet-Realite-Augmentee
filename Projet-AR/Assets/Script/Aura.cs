using UnityEngine;

public class Aura : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public VuforiaObject ChevalierTarget;
    public VuforiaObject AuraTarget;

    public ParticleSystem auraEffect;
    public bool auraActive = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (ChevalierTarget.isDetected && AuraTarget.isDetected)
         {
             if (auraActive == false)
            {
                auraEffect.Play();
                auraActive = true;
            }
            
            
            Debug.Log("Aura Activated");
           
            
             

         }
    }
    
}
