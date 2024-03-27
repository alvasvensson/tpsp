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
    Transform playerPos;
    [SerializeField]
    GameObject fireballPrefab;

    void Start()
    {
        GetComponent<DragonHealth>().SetInitHealth(hp);

    }
    public void SetHP()
    {
    }

    void Update()
    {
        GetComponent<DragonHealth>().UpdateHealth(hp);
        timeBetweenFire += Time.deltaTime;
        if (timeBetweenFire > 4 && playerPos.position.x < 0)
        {
            // animator.Play("drakeSkjuta");
            Instantiate(fireballPrefab, fireballSpawnPos.position, Quaternion.identity);
            timeBetweenFire = 0;
        }
    }

    public void Hurt(int dmg)
    {
        hp -= dmg;
        print("aj");
    }

    public void Attack()
    {

    }
}
