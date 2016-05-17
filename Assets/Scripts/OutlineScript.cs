﻿using UnityEngine;
using System.Collections;

public class OutlineScript : MonoBehaviour
{

    // Use this for initialization
    Color[] lightColors = new Color[6];

    public GameObject[] lights = new GameObject[12];

    float timer = 0;

    public enum lightModes
    {
        staticLights, dynamicLights, reactingLights, partyLights
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

        
    }

    // Update is called once per frame
    void Update()
    {
        if(myLightMode == lightModes.partyLights)
        {
            partyLights();
        }
    }

    void partyLights()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer > 5)
        {
            int activeLight = Random.Range(0, lightColors.Length);
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", lightColors[activeLight]);   
            }
            timer = 0;
        }
        
    }
}
