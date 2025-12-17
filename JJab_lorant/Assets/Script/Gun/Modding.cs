using UnityEngine;

public class Modding : MonoBehaviour
{
    public ModConfig modConfig;
    public GameObject soUmmGiPreview;
    public GameObject scopePreview;

    public void SoUmmGiOn()
    {
        modConfig.hasSoUmmGi = true;
        if (soUmmGiPreview != null)
            soUmmGiPreview.SetActive(true);
    }

    public void SoUmmGiOff()
    {
        modConfig.hasSoUmmGi = false;
        if (soUmmGiPreview != null)
            soUmmGiPreview.SetActive(false);
    }

    public void ScopeOn()
    {
        modConfig.hasGoodScope = true;
        if (scopePreview != null)
            scopePreview.SetActive(true);
    }

    public void ScopeOff()
    {
        modConfig.hasGoodScope = false;
        if (scopePreview != null)
            scopePreview.SetActive(false);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}