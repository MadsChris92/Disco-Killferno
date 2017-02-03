using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunState : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip reloadSound;
    public AudioClip loadSound;
    public AudioClip fireSound;

    public AudioClip emptySound;

    public Animator animator;

    public int bagCap;
    public int magCap;

    internal int bagAmmo
    {
        get { return animator.GetInteger("bagRounds"); }
        set { animator.SetInteger("bagRounds", value); }
    }
    internal int magAmmo
    {
        get { return animator.GetInteger("rounds"); }
        set {
            animator.SetInteger("rounds", value);
            if (value >= magCap) magFull = true;
            else magFull = false;
        }
    }
    bool magFull
    {
        get { return animator.GetBool("full"); }
        set { animator.SetBool("full", value); }
    }
    bool loaded
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
        get { return animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"); }
    }

    public void Reload() {
        if (bagAmmo > 0 && !magFull && !reloading) {
            animator.SetTrigger("reload");
        }
        
    }

    public void OnReloadStart() {
    }

    public void OnReloadEnd() {
    }

    public void OnReload(int amount) {
        if (amount < 1) amount = magCap; // if the amount to reload is less than 1, fill the magazine
        amount = Mathf.Min(bagAmmo, magCap - magAmmo, amount); // only reload with as much as is needed, or available

        magAmmo += amount;
        bagAmmo -= amount;

        audioSource.PlayOneShot(reloadSound);
    }

    public bool Fire() {
        if (loaded) {
            animator.SetTrigger("fire");
            return true;
        } else {
            audioSource.PlayOneShot(emptySound);
        }
        return false;
    }

    public void OnFire() {
        audioSource.PlayOneShot(fireSound);
        loaded = false;
    }

    public void OnLoad() {
        loaded = true;
        magAmmo--;
        audioSource.PlayOneShot(loadSound);
    }
}
