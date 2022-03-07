using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    //SetFLoattaki damp bekleme
    public float damp;
    [Range(1, 20)]
    //Rotation speed basically
    public float rotationSpeed;
    /*
    [Range(1, 20)]
    public float strafeTurnSpeed;
    */
    
    //Kamera koþmazken normal giderken ki uzaklýk
    float normalFov;
    //Koþarken ki Kamera Fovu
    public float sprintFov;
    
    // player grounded mý deðil mi BOOLEANI
    bool isGrounded;
    
    // PLayer koþarken ki speed
    float maxSpeed;
    // Playerýn jump speedi
    [SerializeField] float jump;
    //Basic inputX
    float inputX;
    //Basis inputZ
    float inputZ;


    //Model için Transfrom 
    public Transform model;


    // isGrounded check için groundMask
    [SerializeField] private LayerMask groundMask;
    // Animator almak için
    Animator anim;
    // Basic VECTOR3 haraket için
    Vector3 moveDirection;
    //Kamerayla oynamak için
    Camera mainCam;
    // RIGIDBODY
    Rigidbody rb;
    //Collider
    CapsuleCollider cc;
    

    //Buttons
    public KeyCode SprintButton = KeyCode.LeftShift;
    public KeyCode walkButton = KeyCode.C;
    public KeyCode jumpButton = KeyCode.Space;

    public enum MovementType
    {
        Directional,
        Strafe
    };

    public MovementType movementType;





    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
        normalFov = mainCam.fieldOfView;
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        //isGrounded = Physics.CheckCapsule(cc.bounds.center, new Vector3(cc.bounds.center.x, cc.bounds.min.y - 0.1f, cc.bounds.center.z), 0.18f);
    }

    // Update is called once per frame
    private void Update()
    {
        // Collider dan Physics sýnýfýndan checkCapsule(boolean) method kullanarak grounded mý check ediyoruz 
        isGrounded = Physics.CheckCapsule(cc.bounds.center, new Vector3(cc.bounds.center.x, cc.bounds.min.y - 0.1f, cc.bounds.center.z), 0.18f, groundMask);
        InputMove();
        InputRotation();
        Movement();
        Jump();


    }
    void Movement()
    {
       /* if (movementType == MovementType.Strafe)
        {
            anim.SetFloat("inputX", inputX, damp, Time.deltaTime * 10);
            anim.SetFloat("inputZ", inputZ, damp, Time.deltaTime * 10);

            // var
            bool isMoving = inputX != 0 || inputZ != 0;
            if (isMoving)
            {
                float yawCamera = mainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), strafeTurnSpeed * Time.fixedDeltaTime);
            }
        }
       */



        if (movementType == MovementType.Directional)
        {
            moveDirection = new Vector3(inputX, 0, inputZ);

            //GetKey butona basýlý tutunca calýsmasý acýsýndan 
            if (Input.GetKey(SprintButton))
            {
                //Lerp Kamerayý ileri ve geri haraket ettirecek
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov, Time.deltaTime * 2);

                maxSpeed = 2f;
                inputX = 2 * Input.GetAxis("Horizontal");
                inputZ = 2 * Input.GetAxis("Vertical");
            }
            else if (Input.GetKey(walkButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 0.2f;
                inputX = Input.GetAxis("Horizontal");
                inputZ = Input.GetAxis("Vertical");
            }
            else
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 1f;
                inputX = Input.GetAxis("Horizontal");
                inputZ = Input.GetAxis("Vertical");
            }
        }


        /*
        moveDirection = new Vector3(inputX, 0, inputZ);
        if (Input.GetKey(SprintButton))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov, Time.deltaTime * 2);
            
            maxSpeed = 2f;
            inputX = 2 * Input.GetAxis("Horizontal");
            inputZ = 2 * Input.GetAxis("Vertical");
        }
        else if (Input.GetKey(walkButton))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
            maxSpeed = 0.2f;
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");
        }
        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
            maxSpeed = 1f;
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");
        }
        */
    }

    void InputMove()
    {
        //Hýz 1 olsun istiyoruz ona göre hýzý 0 ile 1 arasýna sabitliyoruz  
        // Time delta yý 10 la çarpýyoruz çünkü haraket etmeyi kesince karakter biraz daha animasyon yemeye devam ediyor
        anim.SetFloat("speed", Vector3.ClampMagnitude(moveDirection, maxSpeed).magnitude, damp, Time.deltaTime * 10);

    }
    void InputRotation()
    {
        //Karakter basýlan tarafa dönsün diye WASD için
        Vector3 rotOfSet = mainCam.transform.TransformDirection(moveDirection);
        rotOfSet.y = 0;
        //Karakterin önü dönsün istediðimiz yere diye 
        //Slerp rotasyon fonksiyonu optimize dönüþ saglýyor
        model.forward = Vector3.Slerp(model.forward, rotOfSet, Time.deltaTime * rotationSpeed);
    }

    void Jump()
    {
        // Ground Check yapýp karakteri zýplatýyoruz ya da zýplatmýyoruz 
        // maksat bir kereden fazla zýplamasýný önlemek
        if (isGrounded&&Input.GetKeyDown(jumpButton))
        {
            rb.AddForce(Vector3.up.normalized * jump);
            
        }
        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            
            anim.SetBool("isJumping", true);
        }
          
    }
}