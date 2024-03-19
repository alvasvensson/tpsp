using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPosController : MonoBehaviour
{

    [SerializeField]
    Transform hpPos;

    [SerializeField]
    Transform charPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hpPos.position = charPos.position;
    }
}
