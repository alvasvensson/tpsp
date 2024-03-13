using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterController : MonoBehaviour
{
    Vector2 movement;
    Animator animator;
    string lastDirection = "right";
    bool isAttacking = false;

    [SerializeField]
    AnimationClip attack;


    int hp = 100;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetHP()
    {
        GetComponent<playerHealth>().SetInitHealth(hp);
    }

    void Update()
    {
        GetComponent<playerHealth>().UpdateHealth(hp);
        if (!isAttacking)
        {
            transform.Translate(movement * 5 * Time.deltaTime);
            if (movement.x > 0)
            {
                animator.Play("walkingright");
                lastDirection = "right";
            }
            else if (movement.x < 0)
            {
                animator.Play("walkingleft");
                lastDirection = "left";
            }
            else if (movement.y > 0)
            {
                animator.Play("walkingup");
            }
            else if (movement.y < 0)
            {
                animator.Play("walkingdown");
            }
            else
            {
                if (lastDirection == "right") { animator.Play("idleright"); }
                if (lastDirection == "left") { animator.Play("idleleft"); }
            }
        }
    }

    public void Hurt(int dmg)
    {
        hp -= dmg;
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void OnFire()
    {
        isAttacking = true;
        animator.Play("attack");

        Invoke("StopAttacking", attack.length);
    }
    void StopAttacking() => isAttacking = false;
}
