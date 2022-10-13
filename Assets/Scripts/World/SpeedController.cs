using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public static float speed = 0f;
    public static float distance;
    static Vector3 move;
    static float reduce = 0.45f;
    GameObject frog;
    static float time=0f;
    float nCount=1;
    public static Vector3 Move { get => move; set => move = value; }
    static bool frozen = false;
    public static Vector3 movedDistance;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("GetFrog", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Time.deltaTime * speed, 0, 0);
        time+=Time.deltaTime;
        movedDistance += new Vector3(Time.deltaTime * speed, 0, 0);
        if (time >= 16&&frozen)
        {
            frozen = false;
            speed += reduce;

        }
        if (frog != null)
        {
            distance = Mathf.Abs(frog.gameObject.transform.position.x);
        }

        if (distance >= 56*nCount)
        {
            nCount++;
            speed +=0.23f;
            if (speed > 1.3)
            {
                speed = 1.3f;
            }
        }
    }
    private void OnEnable()
    {
        if (GameStats.Instance.VirtualLevel > 1)
        {
            speed = GameStats.Instance.ActualSpeed;
            distance=GameStats.Instance.ActualDistance;
            move = GameStats.Instance.RelativeMove;
        }
        else
        {
            distance = 0;
            speed = 0f;
            move = Vector3.zero;
            FrogController.OnFroggoJump += StartSpeed;

        }

    }
    private void OnDisable()
    {
        distance = 0;
        speed = 0f;
        move = Vector3.zero;
        FrogController.OnFroggoJump -= StartSpeed;
    }

    public static void StartSpeed()
    {
        speed = 0.45f;
        FrogController.OnFroggoJump -= StartSpeed;
    }

    void GetFrog()
    {
        distance = 0;
        frog = FrogCentral.frog;
    }

    public static void ReduceTemporal()
    {
        frozen = true;
        time = 0;
        speed -= reduce;
    }
    
    
}
