using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modding : MonoBehaviour
{
    public Gun gun;
    public void EquipStock()
    {
        gun.hasStock = true;
    }

    public void UnequipStock()
    {
        gun.hasStock = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
