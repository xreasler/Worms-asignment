using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cinemachine;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;


public class SwitchManager : MonoBehaviour
{
    
    private static SwitchManager _instance;

    public static SwitchManager instance
    {
        get
        {
            if (_instance == null)
            {
              Debug.LogError("SwitchManager is returning null");  
            }

            return _instance;
        }
    }

    public CinemachineFreeLook  cam1;
    public CinemachineFreeLook  cam2;

    public GameObject player1;
    public GameObject player2;

    public GameObject gameOverMenu;
    public bool isGameOver;
    

    public TMP_Text time;
    public bool timesUp = false;
    public float elapsedTime = 0;
    public float timerTarget = 15;
    
    public TMP_Text hp_01;
    public TMP_Text hp_02;

    public TMP_Text ammo;
    public TMP_Text pTurn;


    
    

    [SerializeField] private float startTime = 15f;
    [SerializeField] private float repeatTime = 20f;


    private void Awake()
    {
        _instance = this;
    }


    public void GameOver()
    {
        
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
        MenuHandler.Instance.mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        LoadMenuScene();

        


    }


    
    void Start()
    {
      cam1.enabled = true;
      cam2.enabled = false;  
      gameOverMenu.SetActive(false);
      MenuHandler.Instance.mainMenu.SetActive(false);
      Time.timeScale = 1f;
      
      isGameOver = false;

      Invoke("Switch", 1f);

    }

    public void MoreTime()
    {
        elapsedTime = 0;
    }

    
    void Update()
    {

        
        
           
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= timerTarget) 
            {
                Switch();
                elapsedTime = 0;
               
            }
        

           

       
        
        


        time.text = elapsedTime.ToString("TIMER:  "+ "0");
        hp_01.text = GameObject.Find("Player1").GetComponent<Target>().health.ToString("Cowboy HP:   " + "0");
        hp_02.text = GameObject.Find("Player2").GetComponent<Target>().health.ToString("Police HP:   " + "0");

        
        





    }

    void Switch()
    {
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
        
        GameObject.Find("Player1").GetComponent<Locomotion>().enabled = !GameObject.Find("Player1").GetComponent<Locomotion>().enabled;
        GameObject.Find("Player2").GetComponent<Locomotion>().enabled = !GameObject.Find("Player1").GetComponent<Locomotion>().enabled;
        
        GameObject.Find("Player1").GetComponent<CharacterShooting>().enabled = !GameObject.Find("Player1").GetComponent<CharacterShooting>().enabled;
        GameObject.Find("Player2").GetComponent<CharacterShooting>().enabled = !GameObject.Find("Player1").GetComponent<CharacterShooting>().enabled;
        
        GameObject.Find("Player1").GetComponent<InputController>().enabled = !GameObject.Find("Player1").GetComponent<InputController>().enabled;
        GameObject.Find("Player2").GetComponent<InputController>().enabled = !GameObject.Find("Player1").GetComponent<InputController>().enabled;
        
        GameObject.Find("Player1").GetComponent<Rigidbody>().isKinematic = !GameObject.Find("Player1").GetComponent<Rigidbody>().isKinematic;
        GameObject.Find("Player2").GetComponent<Rigidbody>().isKinematic = !GameObject.Find("Player1").GetComponent<Rigidbody>().isKinematic;
        
        
        
       
        
        
        
    }
    
    public void LoadMenuScene()
    {
       Debug.Log("Loading Main menu");
        SceneManager.LoadScene("MainMenu");
    }
   
    

    

    
}
