using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{

    public static int point = 0;
    public TextMeshProUGUI points;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points.text = point.ToString("F0");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
