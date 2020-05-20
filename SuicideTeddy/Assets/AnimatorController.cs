using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    public Movimiento mov;
    public Scroll scroll;
    public GameManager gameManager;

    public Animator animator;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(mov.personageRB.velocity.x));
    }

    public void ActivateJump()
    {
        animator.SetTrigger("Jump");
    }

    public void ActivateHitDown()
    {
        animator.SetTrigger("HitDown");
    }

    public void ActivateDead()
    {
        animator.SetTrigger("Dead");
        mov.personageRB.velocity = new Vector3(0, mov.personageRB.velocity.y, 0);
    }

    public void ActivateGameOver()
    {
        mov.personageRB.isKinematic = true;
        mov.personageRB.useGravity = false;

        scroll.baseSpeed = 0;

        gameManager.EndGame();
    }

    public void JumpImpulse()
    {
        mov.ImpulsateJump();
    }
}
