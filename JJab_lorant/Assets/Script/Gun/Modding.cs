using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modding : MonoBehaviour
{
    public PlayerManager pm;
    public GameObject soUmmGiObj;
    public GameObject scope;

    public void OnSoUmmGiToggleChanged(bool isOn)
    {
        if (pm != null)
            pm.SetSoUmmGi(isOn);
    }

    public void OnGoodScopeToggleChanged(bool isOn)
    {
        if (pm != null)
            pm.SetScope(isOn);
    }
}
