using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Studious.SingletonSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Singleton(Name = "Eventhandler", Persistent = true)]

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler Instance => Singleton<MenuHandler>.Instance;

    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
    public void nextscene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainMenu.SetActive(false);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Main menu");
    }
    
}
