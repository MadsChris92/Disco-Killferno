using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Light[] lights = new Light[2]; 
    Color[] lightColors = new Color[6];
    public Color activeColor;


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

        activeColor = lightColors[activeLight];
        gameObject.GetComponent<TrailRenderer>().material.color = lightColors[activeLight];
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Material material = new Material(meshRenderer.material);
        material.color = lightColors[activeLight];
        meshRenderer.material = material;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
