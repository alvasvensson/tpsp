using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballController : MonoBehaviour
{
    [SerializeField]
    float speed = 8;
    Transform playerPos;
    Transform fireballSpawnPos;
    Vector2 target;

    Vector2 velocity;


    void Start()
    {
        playerPos = GameObject.Find("character").transform;
        target = playerPos.position;
        fireballSpawnPos = GameObject.Find("fireballSpawnPos").transform;

        velocity = (target - (Vector2)transform.position).normalized;

    }

    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<characterController>().Hurt(10);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Sword")
        {
            Destroy(this.gameObject);
        }
    }
}
