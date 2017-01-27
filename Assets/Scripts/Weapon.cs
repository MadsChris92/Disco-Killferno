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
    public int bagCap = 27;
    public float recoil = 1.0f;
    public float recoilWidth = 1.0f;
    public float recoilHeight = 1.0f;

    public AudioSource audioSource;
    public AudioClip reloadSound;
    public AudioClip loadSound;
    public AudioClip fireSound;
    public AudioClip emptySound;

    private float recoilX = 0, recoilY = 0;
    private float recoilForce = 0.0f;

    protected int bagAmmo;
    protected int magAmmo
    {
        get
        {
            return animator.GetInteger("rounds");
        }
        set
        {
            animator.SetInteger("rounds", value);
        }
    }
    protected bool loaded
    {
        get
        {
            return animator.GetBool("loaded");
        }
        set
        {
            animator.SetBool("loaded", value);
        }
    }
    private bool reloading
    {
        get { return animator.GetBool("reloading"); }
    }
    // Use this for initialization
    void Start() {
        magAmmo = magCap;
        bagAmmo = bagCap;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            if (loaded) {
				Fire ();
			} else if(magAmmo == 0 && !reloading) {
                audioSource.PlayOneShot(emptySound);
            }
            if (magAmmo == 0 && bagAmmo != 0) {
                Reload();
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
            Reload();
        }
    }

    protected void Fire() {
		GameObject bulletClone = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
		bulletClone.transform.up = bulletSpawn.forward;
		bulletClone.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
		Destroy(bulletClone, 5);

        loaded = false;

		recoilForce += recoil;
		animator.SetTrigger("fire");
        audioSource.PlayOneShot(fireSound);
	}

    protected void Reload() {
        if (bagAmmo > 0 && magAmmo < magCap && !reloading) {
            animator.SetTrigger("reload");
            audioSource.PlayOneShot(reloadSound);
        }
    }

    protected void Reloaded() {
        bagAmmo = Mathf.Max(bagAmmo-(magCap-magAmmo), 0);
        magAmmo = Mathf.Min(magCap, bagAmmo);
        text.text = magAmmo + "/" + magCap + "("+bagAmmo+")";
        audioSource.PlayOneShot(loadSound);
    }

    protected void Load() {
        if (magAmmo > 0 && !loaded) {
            magAmmo--;
        }
        text.text = magAmmo + "/" + magCap + "(" + bagAmmo + ")";
        loaded = true;
    }
}
