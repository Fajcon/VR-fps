using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionDetector : MonoBehaviour
{
    
    public Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene ("MenuScene");
            // pointsText.text = "GAME OVER";
            Debug.Log("Game Over");
        }
    }
    
}
