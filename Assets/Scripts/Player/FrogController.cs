using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FrogController : MonoBehaviour
{
    Animator animator;   
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody rb;
    static Vector3 force;
    static float realForce;
    public static Vector3 playerPos;
   
    private bool isShoot;
    [SerializeField] float forceMultiplier = 2f;
    Frog frog;
    Collider collider;
    bool start;
    bool canJump=true;
    
    public static Vector3 Force { get => force; }

    

    float time;
    public delegate void FroggoJumps();
    public static event FroggoJumps OnFroggoJump;
    public delegate void FroggoLand();
    public static event FroggoLand OnFroggoLand;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        FrogCentral.frog = this.gameObject;
        FrogCentral.frogCollider = this.gameObject.GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        frog = GetComponentInChildren<Frog>();
        collider=GetComponent<Collider>();
    }

    private void Update()
    {
        if (start&& rb.velocity.magnitude <= 0.1&&!canJump)
        {
            canJump = true; 
            DoFroggoLand();
        }
    }

    public void CancelJump()
    {
        Input.ResetInputAxes();
        force = Vector3.zero;
    }

    private void OnMouseDown()
    {
        if (canJump)
        {

            FreePath.endPosition = frog.GetEndPoint(force.magnitude);
            FreePath.highestPoint = frog.GetHighestPoint(force.magnitude);
            mousePressDownPos = Input.mousePosition;
            ActivatePath();
            TouchInput.Enable();
            CancelInput.Enable();
        }
    }
 
    private void OnMouseDrag()
    {
  
        if (canJump)
        {
            time += Time.deltaTime;
            animator.SetBool("Prepare", true); 

            force = (mousePressDownPos - Input.mousePosition) * 0.01f * forceMultiplier;
            realForce = AutomaticJump.GetInitialVelocity(frog.GetEndPoint(force.magnitude), this.gameObject);
          
            if (force.y >= 0.5)
            {
                ActivatePath();
                FreePath.endPosition = frog.GetEndPoint(force.magnitude);
                FreePath.highestPoint = frog.GetHighestPoint(force.magnitude);
                
                frog.changeRotation(GetAngle(mousePressDownPos, Input.mousePosition));
            }
            
        }
       
        

    }


    public void DoFroggoLand()
    {
        if (OnFroggoLand != null)
        {
            animator.SetBool("Jumping", false); 
            playerPos = transform.position;
            ActivateJump();
            if (OnFroggoLand != null)
            {
                OnFroggoLand();

            }

        }
    }

    public void DeActivateJump()
    {
        collider.enabled = false;
    }

    public void ActivateJump()
    {
        collider.enabled = true;
    }

    private void OnMouseUp()
    {
        animator.SetBool("Prepare", false);

        if (canJump )
        {
            mouseReleasePos = Input.mousePosition;
            if (force.magnitude >= 4f && ((mousePressDownPos.y - 0.5f) >= mouseReleasePos.y))
            {
                Shoot(realForce, GetAngle(mousePressDownPos, mouseReleasePos));
            }
            FreePath.active = false;
            time=0;
            TouchInput.Disable();
            CancelInput.Disable();
        }
    }

    public void Shoot(float vo, float a)
    {
        if (isShoot)
            return;
        canJump = false;

        if (force.y >= 0)
        {
            start = true;
            canJump = false;
            rb.transform.eulerAngles = new Vector3(this.transform.rotation.x, a, this.transform.rotation.z);

            rb.velocity= (transform.TransformDirection(new Vector3((vo) * Mathf.Cos(45), (vo) * Mathf.Sin(45), 0)));
            rb.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);
            force = Vector3.zero;
            realForce=0;
            if (OnFroggoJump != null)
            {
                OnFroggoJump();

            }
            animator.SetBool("Jumping", true); 
            DeActivateJump();
        


        }

    }

    static float GetAngle(Vector3 mousePressDownPos, Vector3 mouseReleasePos)
    {
       
        float signedAngle;
        float a = mousePressDownPos.y - mouseReleasePos.y;
        float h = Mathf.Abs(mouseReleasePos.x - (Screen.width / 2)) + 0.0001f;

        if (mouseReleasePos.x > (Screen.width / 2))
        {
            signedAngle = -(Mathf.Atan2(h, a) * Mathf.Rad2Deg);
        }
        else
        {
            signedAngle = (Mathf.Atan2(h , a) *Mathf.Rad2Deg);

        }


        return signedAngle;
    }

    private void OnEnable()
    {
        Pause.OnGamePause += ChangeLayer;
        Pause.OnGameResume += ResetLayer;
    }
    private void OnDisable()
    {
        Pause.OnGamePause -= ChangeLayer;
        Pause.OnGameResume -= ResetLayer;

    }
    void ActivatePath()
    {
        FreePath.active = true;
    }
    void ChangeLayer()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        foreach (Transform t in transform)
        {
            t.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }
    void ResetLayer()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");

        foreach (Transform t in transform)
        {
            t.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}