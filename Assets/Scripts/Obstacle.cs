using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public float speed;
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
        Destroy(gameObject, 20);
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
    
}
