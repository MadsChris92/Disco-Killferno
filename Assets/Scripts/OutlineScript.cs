﻿using UnityEngine;
using System.Collections;

public class OutlineScript : MonoBehaviour
{

    // Use this for initialization
    Color[] lightColors = new Color[6];

    public GameObject[] lights = new GameObject[12];
    public AudioClip hitSound;

    Color reactingLightsColor = Color.red;

    public Color staticColor;

    float timer = 0;
    public float dynamicBlinkInterval = 3;

    

    public enum lightModes
    {
        staticLights, dynamicLights, reactingLights, partyLights, reactingWithSound
    }
    public lightModes myLightMode;

    void Start()
    {
        lightColors[0] = Color.red;
        lightColors[1] = Color.cyan;
        lightColors[2] = Color.blue;
        lightColors[3] = Color.green;
        lightColors[4] = Color.yellow;
        lightColors[5] = Color.magenta;

        if(myLightMode == lightModes.staticLights)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", staticColor);
            }
        }

        if (myLightMode == lightModes.dynamicLights)
        {
            int activeLight = Random.Range(0, lightColors.Length);
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", lightColors[activeLight]);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myLightMode == lightModes.reactingLights)
        {
            reactingLights();
        }

        if(myLightMode == lightModes.dynamicLights)
        {
            dynamicLight();
        }

        if(myLightMode == lightModes.reactingWithSound)
        {
            reactWithSound();
        }

        //bla
    }

    void dynamicLight()
    {
        timer += Time.deltaTime;
        if(timer > dynamicBlinkInterval)
        {
            int activeLight = Random.Range(0, lightColors.Length);
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", lightColors[activeLight]);   
            }
            timer = 0;
        }  
    }

    void reactingLights()
    {
        reactingLightsColor = gameObject.GetComponent<Objects>().hitColor;

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", reactingLightsColor);
        }
    }

    void reactWithSound()
    {
        reactingLightsColor = gameObject.GetComponent<Objects>().hitColor;

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", reactingLightsColor);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Projectile")
        {
            Debug.Log("test");
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
