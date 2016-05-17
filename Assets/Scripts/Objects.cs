using UnityEngine;
using System.Collections;

public class Objects : MonoBehaviour {

    public Color hitColor;
    
	void Start () {
        
	}
	
	void Update () {

	}


    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Projectile")
        {
           hitColor = c.gameObject.GetComponent<Bullet>().activeColor;
        }
    }
}
