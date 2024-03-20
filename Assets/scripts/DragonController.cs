using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    Animator animator;
    int hp = 100;
    float timeBetweenFire;
    [SerializeField]
    Transform fireballSpawnPos;
    [SerializeField]
    GameObject fireballPrefab;

    void Start()
    {

    }
    public void SetHP()
    {
        GetComponent<DragonHealth>().SetInitHealth(hp);
    }

    void Update()
    {
        GetComponent<DragonHealth>().UpdateHealth(hp);
        timeBetweenFire += Time.deltaTime;
        if (timeBetweenFire > 4)
        {
            animator.Play("drakeSkjuta");
            Instantiate(fireballPrefab, fireballSpawnPos.position, Quaternion.identity);
            timeBetweenFire = 0;
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
