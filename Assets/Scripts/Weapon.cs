using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    public GunState gunState;
    public Text ammoIndicator;
    public GameObject bullet;
    public float bulletSpeed = 100;
    public Transform bulletSpawn;
    public Transform gunTransform;


    public float recoil = 1.0f;
    public float recoilWidth = 1.0f;
    public float recoilHeight = 1.0f;
    private float recoilX = 0, recoilY = 0;
    private float recoilForce = 0.0f;
    

    // Use this for initialization
    void Start() {
        gunState.magAmmo = gunState.magCap;
        gunState.bagAmmo = gunState.bagCap;
        ammoIndicator.text = gunState.magAmmo + "/" + gunState.magCap;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            if (gunState.Fire()) {
                Fire();
                ammoIndicator.text = gunState.magAmmo + "/" + gunState.magCap;
            }
        }

        if (recoilForce < 0.1) recoilForce = 0;
        else {
            //gunTransform.forward = (transform.forward + transform.right * recoilX + transform.up * recoilY);
            recoilX = Mathf.Lerp(recoilX, Mathf.Lerp(0, Random.Range(-recoilWidth / 2, recoilWidth / 2), recoilForce / 10.0f), 0.1f);
            recoilY = Mathf.Lerp(0, recoilHeight, recoilForce / 10.0f);
            recoilForce -= recoilForce / 10;
        }

        if(Input.GetButtonDown("Reload")) {
            gunState.Reload();
        }
    }

    protected void Fire() {
		GameObject bulletClone = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
		bulletClone.transform.up = bulletSpawn.forward;
		bulletClone.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
		Destroy(bulletClone, 5);

		recoilForce += recoil;
	}
}
