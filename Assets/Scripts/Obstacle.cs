using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public float speed;
    
    private Vector3 direction;
    private Vector3 velocity;
    

    
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.back;
        velocity = speed * direction;
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }
}
