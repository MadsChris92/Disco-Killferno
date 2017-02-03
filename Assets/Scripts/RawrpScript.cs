using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawrpScript : MonoBehaviour {

    public GunState gunstate;
    public GameObject[] rounds;

    void ReloadRawrp() {
        RoundsActive(gunstate.magAmmo + 1);
    }

    void LoadRawrp() {
        RoundsActive(gunstate.magAmmo);
    }

    private void RoundsActive(int ammo) {
        for (int i = 0; i < rounds.Length; i++) {
            rounds[i].SetActive(i < ammo);
        }
    }
}
