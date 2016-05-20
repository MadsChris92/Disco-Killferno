using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


    public GameObject bullet;
    public float bulletSpeed = 100;
    public Animator[] animator;
    public Transform[] bulletSpawn;
    private int current = 0;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletClone = Instantiate(bullet, bulletSpawn[current].transform.position, Quaternion.identity) as GameObject;
            bulletClone.transform.up = transform.forward;
            bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            Destroy(bulletClone, 5);

            animator[current].SetTrigger("fire");
            gameObject.GetComponent<AudioSource>().Play();

            current = 1-current;
        }

        if(Input.GetButtonDown("Reload")) {
            animator[current].SetTrigger("reload");
        }
    }
}
