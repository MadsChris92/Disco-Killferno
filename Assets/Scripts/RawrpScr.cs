using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawrpScr : StateMachineBehaviour {

    public AudioSource audioSource;
    public AudioClip reloadSound;
    public AudioClip loadSound;
    public AudioClip fireSound;
    public AudioClip emptySound;

    public Animator animator;

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

    public GameObject[] rounds;

    void ReloadRawrp() {
        RoundsActive(magAmmo + 1);
    }

    void Reloaded() {
        /*magAmmo = Mathf.Min(magCap, magAmmo + 1);
        if (magAmmo == magCap) {
            animator.SetTrigger("reloaded");
        }*/

        RoundsActive(magAmmo);
        audioSource.PlayOneShot(loadSound);
    }

    void Load() {
        //base.Load();
        RoundsActive(magAmmo);
    }

    void RoundsActive(int ammo) {
        for (int i = 0; i < rounds.Length; i++) {
            rounds[i].SetActive(i < ammo);
        }
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Shoot"))
            animator.SetBool("loaded", false);

        if (stateInfo.IsName("Reload"))
            animator.SetBool("reloading", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Load"))
            animator.SetBool("loaded", true);

        if (stateInfo.IsName("Reload"))
            animator.SetBool("reloading", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
