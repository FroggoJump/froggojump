using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticJump : MonoBehaviour
{

    GameObject f;
    public WaterLily[] waterLilys;
    bool canJump;
    bool startJump=true;
    float v0;
    int waterLilyPos=1;
    float angle;
    int counter;
    float timer;
    float time=0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            f= other.gameObject.GetComponentInParent<FrogController>().gameObject;
            RandomFly.Activate();
            Debug.Log("paso1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (f != null)
        {
            f.GetComponent<FrogController>().DeActivateJump();

            timer += Time.deltaTime;

            if (timer >= time)
            {
                JumpF(waterLilyPos);
                waterLilyPos++;
                timer = 0;
            }
            if (counter >= waterLilys.Length - 1)
            {
                f.GetComponent<FrogController>().ActivateJump();
                RandomFly.Deactivate();

                this.enabled = false;


            }
        }
    


    }

    void JumpF(int position)
    {
        if (waterLilys.Length>position)
        {

            counter++;

            angle = 0;
            Vector3 target = waterLilys[position].gameObject.transform.position;
            Frog.nextPos = target;
            v0 = GetInitialVelocity(target, f);
            float distance = CalcDistance(f, target);
            f.GetComponent<FrogController>().Shoot(v0, -CalcAngle(target, f.transform));
            f.GetComponentInChildren<Frog>().changeRotation(-CalcAngle(target, f.transform));

            time = GetTime(distance,v0,f)+0.5f;
        }
        
    }
    public static float CalcDistance(GameObject frog, Vector3 target)
    {
        return Vector3.Distance(frog.transform.position, target);
    }
    public static float GetTime(float distance, float v0, GameObject frog)
    {
        return ((distance) / (v0 * Mathf.Cos(45)));
    }

    public static float CalcAngle(Vector3 target,Transform from)
    {

        Vector3 targetDir = (target - from.position).normalized;
        Vector3 forward = from.right;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);

        return angle;
    }
    
    public static float GetInitialVelocity(Vector3 pos, GameObject frog)
    {
        float initialVelocity;
        Vector3 target = pos;
        float distance = Vector3.Distance(frog.transform.position, target);
        initialVelocity = Mathf.Sqrt((distance * 9.81f) / Mathf.Sin(2 *45));
        return initialVelocity;
    }

    public static float GetTime(float vo)
    {
        return ((2f * vo * Mathf.Sin(45)) / Physics.gravity.y);
    }
}
