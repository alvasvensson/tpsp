using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterController : MonoBehaviour
{
    Vector2 movement;
    Animator animator;
    string lastDirection = "right";
    bool isAttacking = false;
    HashSet<GameObject> currentEnemiesInRange = new();

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


        if (isAttacking)
        {
            if (currentEnemiesInRange.Count >= 1)
            {

                foreach (GameObject e in currentEnemiesInRange)
                {
                    if (e.tag == "Dragon")
                    {
                        DragonController d = e.GetComponent<DragonController>();
                        if (d)
                        {
                            d.Hurt(10);
                        }
                    }
                }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dragon")
        {
            print("Added " + other.name);
            currentEnemiesInRange.Add(other.gameObject);
            print(currentEnemiesInRange.Count);
        }
        // print("enter");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentEnemiesInRange.Remove(other.gameObject);
    }
}
