using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    int hp = 100;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetHP()
    {
        GetComponent<DragonHealth>().SetInitHealth(hp);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<DragonHealth>().UpdateHealth(hp);
    }

    public void Hurt(int dmg)
    {
        hp -= dmg;
    }

    public void Attack()
    {
        
    }
}
