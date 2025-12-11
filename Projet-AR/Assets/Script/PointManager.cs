using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    public static int score = 0;
    public TextMeshProUGUI points;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
        points.text = score.ToString("F0");
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        if (points != null)
            points.text = score.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
