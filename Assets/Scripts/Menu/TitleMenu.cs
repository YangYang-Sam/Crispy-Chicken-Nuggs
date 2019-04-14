using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public string newGamescene;
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGamescene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Fade()
    {
        fade.SetActive(true);
    }
}
