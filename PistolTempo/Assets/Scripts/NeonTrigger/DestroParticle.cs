using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroParticle : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {
        DestroyParticle();
    }

    void DestroyParticle()
    {
        
        Destroy(gameObject, 2f);
    }
}
