using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Head : Boss
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= pm.critDamage;
            Debug.Log("Boss Hit! Current HP: " + hp);

            if (hp == 0)
                Destroy(gameObject);
        }
    }
}
