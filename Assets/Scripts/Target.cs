using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    public float speed;
    public TargetSpawner targetSpawner;
    
    private Vector3 direction;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.back;
        velocity = speed * direction;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
        targetSpawner.points++;
        targetSpawner.pointsText.text = targetSpawner.points.ToString();
    }
}
