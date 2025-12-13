using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public float showDelay = 19f;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void ShowButton()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(showDelay);
        gameOverPanel.SetActive(true);
    }

    public void Replay()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}
