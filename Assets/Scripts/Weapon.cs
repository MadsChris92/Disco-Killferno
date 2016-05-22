using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {


    public Text text;
    public GameObject bullet;
    public float bulletSpeed = 100;
    public Animator animator;
    public Transform bulletSpawn;
    public Transform gunTransform;
    public int magCap = 9;
    float recoilX = 0, recoilY = 0;
    public float recoil = 1.0f;
    public float recoilWidth = 1.0f;
    public float recoilHeight = 1.0f;
    float recoilForce = 0.0f;
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
                GameObject bulletClone = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
                bulletClone.transform.forward = transform.forward;
                bulletClone.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
                Destroy(bulletClone, 5);

                ammo--;
                text.text = ammo + "/" + magCap;

                recoilForce += recoil;
                animator.SetTrigger("fire");
                gameObject.GetComponent<AudioSource>().Play();
            }
        }

        if (recoilForce < 0.1) recoilForce = 0;
        else {
            gunTransform.forward = (transform.forward + transform.right * recoilX + transform.up * recoilY);
            recoilX = Mathf.Lerp(recoilX, Mathf.Lerp(0, Random.Range(-recoilWidth / 2, recoilWidth / 2), recoilForce / 10.0f), 0.1f);
            recoilY = Mathf.Lerp(0, recoilHeight, recoilForce / 10.0f);
            recoilForce -= recoilForce / 10;
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
