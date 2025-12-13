using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject WinPannel;
    public GameObject Boss;
    public GameObject Mob;
    public GameObject Mob2;
    public AudioPlayer ap;

    // Start is called before the first frame update
    void Start()
    {
        WinPannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss == null && Mob == null && Mob2 == null)
        {
            WinPannel.SetActive(true);
            ap.WinSound();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Replay()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void Exit()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index - 1);
    }
}
