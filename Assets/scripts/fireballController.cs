using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballController : MonoBehaviour
{
    [SerializeField]
    float speed = 8;
    Transform playerPos;
    Transform fireballSpawnPos;

    void Start()
    {
        playerPos = GameObject.Find("character").transform;
        fireballSpawnPos = GameObject.Find("fireballSpawnPos").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
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
