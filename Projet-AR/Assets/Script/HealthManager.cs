using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    public Image healthbararcher;
    public Image dragonHealthBar;
    public float dragonHealth = 300f;
    public float dragonMaxHealth = 300f;
    public float health2 = 50f;
    public float maxHealth2 = 50f;
    public static HealthManager instance;

    // Update is called once per frame
    void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        healthbararcher.fillAmount = health2 / maxHealth2;
        dragonHealthBar.fillAmount = dragonHealth / dragonMaxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void TakeDamage2(float damage)
    {
        health2 -= damage;
    }
    public void TakeDamageDragon(float damage)
    {
        dragonHealth -= damage;
    }
    
}
