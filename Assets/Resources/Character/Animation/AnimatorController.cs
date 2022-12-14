using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator _animator;

    bool IsWalking; 
    bool IsJumping;
    bool IsShooting;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        IsWalking = false;
        IsJumping = false;
        IsShooting = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Set the "Jump" parameter in the Animator Controller to true
            Debug.Log("am i walking?");
            _animator.SetBool("IsWalking", true);
            //Check to see if the "Crouch" parameter is enabled
            
        }
        //Otherwise the "Jump" parameter should be false
        else _animator.SetBool("IsWalking", false); 
        
        if (Input.GetKey(KeyCode.Space))
        {
            //Set the "Jump" parameter in the Animator Controller to true
            _animator.SetBool("IsJumping", true);
            //Check to see if the "Crouch" parameter is enabled
            
        }
        //Otherwise the "Jump" parameter should be false
        else _animator.SetBool("IsJumping", false);

        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("IsShooting", true);
        }
        else _animator.SetBool("IsShooting", false);
        
            
    }
}
