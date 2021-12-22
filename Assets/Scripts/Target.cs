using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    public float speed;
    public TargetSpawner targetSpawner;
    private float spawnSpeed = 40;
    private Vector3 spawnVelocity;
    
    private Vector3 direction;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.back;
        velocity = speed * direction;
        spawnVelocity = spawnSpeed * direction;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 10)
        {
            transform.Translate(spawnVelocity * Time.deltaTime);
        }
        else
        {
            transform.Translate(velocity * Time.deltaTime);
        }
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
        targetSpawner.points++;
        targetSpawner.pointsText.text = targetSpawner.points.ToString();
    }
}
