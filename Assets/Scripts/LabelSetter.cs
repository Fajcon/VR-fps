using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelSetter : MonoBehaviour
{
    public Material defaultMaterial;
    public Material pudliszkiMaterial;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = defaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
