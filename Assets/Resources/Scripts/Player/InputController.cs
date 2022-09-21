using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Locomotion charController;
    private Animator anim;

    void Awake()
    {
        charController = GetComponent<Locomotion>();
        anim =GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Get input values
        
        int vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        int horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        bool jump = Input.GetKey(KeyCode.Space);
        charController.ForwardInput = vertical;
        charController.TurnInput = horizontal;
        charController.JumpInput = jump;
        
    }
    

}
