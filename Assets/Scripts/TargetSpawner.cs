using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    
    public GameObject targetPrefab;

    public int speed;
    public int minX;
    public int maxX;

    public int maxY;
    
    public Text pointsText;
    public int points = 0;

    /**
     * Time between targets spawn in seconds
     * todo change to table all random
     */
    public float spawnPeriod;
    
    private float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= spawnPeriod)
        {
            elapsed = elapsed % spawnPeriod;
            var position = this.transform.position;
            position.x += Random.Range(minX, maxX);
            position.y += Random.Range(0.5f, maxY);
            var targetObject = Instantiate(targetPrefab, position, Quaternion.identity);
            targetObject.GetComponent<Target>().targetSpawner = this;
            targetObject.GetComponent<Target>().speed = speed;

        }
    }
}
