using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    
    public GameObject targetPrefab;
    public Gun leftGun;
    public Gun rightGun;

    public int minX;
    public int maxX;

    public int maxY;

    public float speed;

    public Text pointsText;
    private int points = 0;

    /**
     * Time between targets spawn in seconds
     * todo change to table all random
     */
    public float spawnPeriod;
    
    private float elapsed = 0f;
    private List<GameObject> targets;
    private Vector3 direction;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
        direction = Vector3.back;
        velocity = speed * direction;
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
            position.y += Random.Range(0, maxY);
            var targetObject = Instantiate(targetPrefab, position, Quaternion.identity);
            
            targets.Add(targetObject);
        }

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.Remove(targets[i]);
                points++;
                pointsText.text = "Points: " + points;
            }
            else
            {
                targets[i].transform.Translate(velocity * Time.deltaTime);
            }
        }
    }
}
