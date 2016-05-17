using UnityEngine;
using System.Collections;

public class Objects : MonoBehaviour {

    // Use this for initialization
    LineRenderer lr;
    Vector3[] posisions = new Vector3[3];
    
	void Start () {
        
        for(int  i = 0; i < posisions.Length; i++)
        {
//            posisions[i] = new Vector3(gameObject.tra)
        }

        lr = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
