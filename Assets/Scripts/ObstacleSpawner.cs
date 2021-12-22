using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    
    public int minX;
    public int maxX;

    public int speed;

    /**
     * Time between targets spawn in seconds
     * todo change to table all random
     */
    public float spawnPeriod;

    public float changeSpeedPeriod;

    public float decreasePeriod;
    
    private float elapsed = 0f;
    private float elapsedTimeForChangeSpeed = 0f;
    private float elapsedTimeForChangePeriod = 0f;

// Start is called before the first frame update
    void Start()
    {
        
    }

    void changeSpeed()
    {
        speed += 1;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        elapsedTimeForChangeSpeed += Time.deltaTime;
        elapsedTimeForChangePeriod += Time.deltaTime;

        if (elapsedTimeForChangeSpeed >= changeSpeedPeriod)
        {
            changeSpeed();
            elapsedTimeForChangeSpeed = elapsedTimeForChangeSpeed % changeSpeedPeriod;
        }
        
        if (elapsed >= spawnPeriod)
        {
            var index = Random.Range(0, obstaclePrefabs.Length);
            elapsed = elapsed % spawnPeriod;
            var position = this.transform.position;
            position.x += Random.Range(minX, maxX);
            position.y += obstaclePrefabs[index].transform.position.y;
            var targetObject = Instantiate(obstaclePrefabs[index], position, Quaternion.identity);
            targetObject.GetComponent<Obstacle>().speed = speed;
        }

        if (spawnPeriod >= 0.1f && elapsedTimeForChangePeriod >= decreasePeriod)
        {
            spawnPeriod -= 0.5f;
            if (spawnPeriod < 0.1f)
            {
                spawnPeriod = 0.1f;
            }
            elapsedTimeForChangePeriod = elapsedTimeForChangePeriod % spawnPeriod;

        }
    }
}
