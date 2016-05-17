using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


    public GameObject bullet;
    public float bulletSpeed = 100;
    public Animator animator;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
            bulletClone.transform.up = transform.forward;
            bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            Destroy(bulletClone, 5);
            animator.SetTrigger("fire");
        }
    }
}
