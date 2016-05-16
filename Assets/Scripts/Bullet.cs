using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Light[] lights = new Light[2]; 
    Color[] lightColors = new Color[6];


	void Start () {
        lightColors[0] = Color.red;
        lightColors[1] = Color.cyan;
        lightColors[2] = Color.blue;
        lightColors[3] = Color.green;
        lightColors[4] = Color.yellow;
        lightColors[5] = Color.magenta;
        int activeLight = Random.Range(0, lightColors.Length);

        for(int i = 0; i < lights.Length; i++)
        {
            lights[i].color = lightColors[activeLight];
        }

        gameObject.GetComponent<TrailRenderer>().material.color = lightColors[activeLight];

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
