using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayData : MonoBehaviour
{
    
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        accuracyText.text = "Accuracy: " + (GameData.accurateShots / GameData.shots).ToString("0.00");
        pointsText.text = "Points: " + GameData.accurateShots;
        timeText.text = "Time: " + (GameData.endTime - GameData.startTime).ToString(@"mm\:ss");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
