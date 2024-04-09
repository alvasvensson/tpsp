using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    Animator animator;
    int hp = 100;
    float timeBetweenFire;
    float animTime = 0;
    bool dragonDead = false;
    [SerializeField]
    Transform fireballSpawnPos;
    [SerializeField]
    Transform playerPos;
    [SerializeField]
    GameObject fireballPrefab;

    void Start()
    {
        GetComponent<DragonHealth>().SetInitHealth(hp);
        animator = GetComponent<Animator>();
    }
    public void SetHP()
    {
    }

    void Update()
    {
        GetComponent<DragonHealth>().UpdateHealth(hp);
        timeBetweenFire += Time.deltaTime;
        animTime += Time.deltaTime;
        if (timeBetweenFire > 4 && playerPos.position.x < 0 && !dragonDead)
        {
            animator.Play("drakeSkjuta");
            animTime = 0;
            Instantiate(fireballPrefab, fireballSpawnPos.position, Quaternion.identity);
            timeBetweenFire = 0;
        }
        if (animTime > 0.5 && !dragonDead)
        {
            animator.Play("drakeIdle");
        }
        if (hp <= 0)
        {
            animator.Play("drakeDead");
            dragonDead = true;
        }
    }

    public void Hurt(int dmg)
    {
        hp -= dmg;
    }

    public void Attack()
    {

    }
}
