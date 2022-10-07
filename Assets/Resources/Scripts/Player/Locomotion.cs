using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    [Tooltip("maxium slope the player can jump on")]
    public float moveSpeed = 5f;
    public float turnspeed = 300f;
    private Vector2 _playerDirection;
    Vector3 raycastOffset;
    public Animator anim;
    public float speed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
     
    public bool isGrounded;
    

    private GameObject player;

    public bool IsGrounded { get; private set; }
    public float ForwardInput { get; set; }
    public float TurnInput { get; set; }
    public bool JumpInput { get; set; }
    
     

    public Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    public Transform cam;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        capsuleCollider = rb.GetComponent<CapsuleCollider>();
        Cursor.lockState = CursorLockMode.Locked;
        player = gameObject;
        
        rb.AddForce(-transform.up);
        jump = new Vector3(0.0f, 20.0f, 0.0f);
       



    }
    

    
    void FixedUpdate()
    {      
        ProcessAction();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Invoke("ForceDown", 0.1f);
            Invoke("ReturnGrav", 1f);
            
            
        }

    }

    void ForceDown()
    {
        Physics.gravity = new Vector3(0, -900.0F, 0);
    }
    void ReturnGrav()
    {
        Physics.gravity = new Vector3(0, -9.0F, 0);
    }
    
    
    



    void ProcessAction()
    {
        
        float angle = Mathf.Clamp(TurnInput, -1f, 1f) * turnspeed;
        transform.Rotate(Vector3.up, Time.fixedDeltaTime * angle);
       
       
            Vector3 inputVector = new Vector3(_playerDirection.x, 0, _playerDirection.y); 


            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x,
                cam.transform.eulerAngles.y, player.transform.eulerAngles.z);


            inputVector = player.transform.TransformDirection(inputVector);

            rb.velocity = inputVector * moveSpeed;  
            
            rb.velocity += transform.forward * Mathf.Clamp(ForwardInput, -1f, 1f) * moveSpeed;
            
            if (Input.GetKey("a")) {
                rb.AddForce (-Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey("d")) {
                rb.AddForce (Vector3.right * speed * Time.deltaTime);
            }
            
            

           
    
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    
    

}
