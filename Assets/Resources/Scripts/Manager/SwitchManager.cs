using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cinemachine;
using UnityEngine;
using Studious.SingletonSystem;
using UnityEngine.UI;

public class SwitchManager : MonoBehaviour
{

    public CinemachineFreeLook  cam1;
    public CinemachineFreeLook  cam2;

    public GameObject player1;
    public GameObject player2;

    public Text time;

    [SerializeField] private float starttime = 15f;
    [SerializeField] private float repeattime = 20f;
    
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
      cam1.enabled = true;
      cam2.enabled = false;  
      
      InvokeRepeating("Switch", starttime, repeattime);
      
    }

    
    void Update()
    {

        //time.text = string.Format("{1:00}", repeattime);

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
        
        
        
       
        
        
        
    }

    
}
