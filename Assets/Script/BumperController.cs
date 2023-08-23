using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxManager;

    // untuk mengakses score manager
    public ScoreManager scoreManager;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //Animasi
            animator.SetTrigger("Hit");

            //play SFX
            audioManager.PlaySFX(collision.transform.position);

            //play VFX
            vfxManager.PlayVFX(collision.transform.position);

            //tambah score saat menabrak bumper
            scoreManager.AddScore(score);
        }
    }
}
