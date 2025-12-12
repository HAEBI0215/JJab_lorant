using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodDamitScope : MonoBehaviour
{
    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun.scopeFov = 100;
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
