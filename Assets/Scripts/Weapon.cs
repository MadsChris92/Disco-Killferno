using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {


    public Text text;
    public GameObject bullet;
    public float bulletSpeed = 100;
    public Animator animator;
    public Transform bulletSpawn;
    public int magCap = 9;
    private int ammo = 0;

    // Use this for initialization
    void Start() {
        Reload();
    }

    // Update is called once per frame
    void Update() {

        if (animator.GetBool("reloaded")) {
            animator.SetBool("reloaded", false);
            Reload();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo == 0) animator.SetTrigger("reload");
            else {
                ammo--;
                text.text = ammo + "/" + magCap;
                GameObject bulletClone = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
                bulletClone.transform.forward = transform.forward;
                bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
                Destroy(bulletClone, 5);

                animator.SetTrigger("fire");
                gameObject.GetComponent<AudioSource>().Play();
            }
        }

        if(Input.GetButtonDown("Reload")) {
            animator.SetTrigger("reload");
        }
    }

    void Reload() {
        ammo = magCap;
        text.text = ammo + "/" + magCap;
    }
}
