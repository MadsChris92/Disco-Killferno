using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


    public GameObject bullet;
    public float bulletSpeed = 100;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
            bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Force);
        }
    }
}
