using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawrpScript : Weapon {

    public GameObject[] rounds;

    void ReloadRawrp() {
        RoundsActive(magAmmo+1);
    }

    new void Reloaded() {
        magAmmo = Mathf.Min(magCap, magAmmo+1);
        if (magAmmo == magCap) {
            animator.SetTrigger("reloaded");
        }
        text.text = magAmmo + "/" + magCap + "(" + bagAmmo + ")";
        RoundsActive(magAmmo);
    }

    new void Load() {
        base.Load();
        RoundsActive(magAmmo);
    }

    void RoundsActive(int ammo) {
        for (int i = 0; i < rounds.Length; i++) {
            rounds[i].SetActive(i < ammo);
        }
    }
}
