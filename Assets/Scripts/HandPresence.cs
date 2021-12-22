using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private InputDevice secondHand;
    public XRNode inputSource;

    public Gun gunScript;
    public GameObject handModelPrefab;
    public bool menuOn;

    private Animator handAnimator;
    private GameObject spawnedHandModel;

    private GameObject barrel;
    private AudioSource audioSource;

    private Boolean triggerReleased = true;
    
    private Color startColor = Color.red;
    private Color endColor = Color.white;
    private GameObject target;
    private Boolean onTarget;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        spawnedHandModel = Instantiate(handModelPrefab, this.transform);

        barrel = spawnedHandModel.transform.Find("Barrel").gameObject;
        audioSource = spawnedHandModel.transform.Find("Audio").gameObject.GetComponent<AudioSource>();
    }

    void Shoot()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            if (triggerReleased && triggerValue > 0.5f)
            {
                gunScript.Fire(barrel, audioSource, target);
                triggerReleased = false;
            }
            else if (triggerValue < 0.7f)
            {
                triggerReleased = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        secondHand = InputDevices.GetDeviceAtXRNode(inputSource);
        spawnedHandModel.SetActive(true);
    }

    private void FixedUpdate()
    {
        Shoot();
        LineRenderer lineRenderer = barrel.GetComponent<LineRenderer>();
        int layerMask = 1 << 2;
        layerMask = ~layerMask;

        RaycastHit hit;

        lineRenderer.SetWidth(0.01f, 0.01f);
        lineRenderer.SetPosition(1, new Vector3(0, 0, 1) * 50);
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        lineRenderer.positionCount = 2;

        Gradient gradient = new Gradient();

        lineRenderer.endColor = Color.white;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Did Hit");

            lineRenderer.SetPosition(1, new Vector3(0, 0, 1) * hit.distance);
            startColor = Color.green;
            float alpha = 1.0f;
            gradient.SetKeys(
                new GradientColorKey[] {new GradientColorKey(startColor, 0.0f), new GradientColorKey(endColor, 1.0f)},
                new GradientAlphaKey[] {new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f)}
            );
            lineRenderer.colorGradient = gradient;
            target = hit.collider.gameObject;
            onTarget = true;
        }
        else
        {
            Debug.Log("Did not Hit");

            lineRenderer.SetPosition(1, new Vector3(0, 0, 1) * 50);
            startColor = Color.red;
            float alpha = 1.0f;
            gradient.SetKeys(
                new GradientColorKey[] {new GradientColorKey(startColor, 0.0f), new GradientColorKey(endColor, 1.0f)},
                new GradientAlphaKey[] {new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f)}
            );
            lineRenderer.colorGradient = gradient;
            onTarget = false;
        }
    }
}