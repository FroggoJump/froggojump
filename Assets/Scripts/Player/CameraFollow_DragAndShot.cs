using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_DragAndShot : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform cameraStartPos;
    //[SerializeField] Transform end;
    [SerializeField] Transform parent;
    [Header("WorldMovement")]
    [SerializeField] float speed;
    float xJump;
    public float realSpeed;
    float time;
    float acceleration;
    bool follow;
    Vector3 targetPosition;
    Vector3 smoothPosition;
    [SerializeField] float strength;
  
 
    void FixedUpdate()
    {
        if(player != null)
        {
            time += Time.fixedDeltaTime;

            if (time < 0.8f)
            {
                targetPosition = player.position + offset;
                smoothPosition = Vector3.Lerp(parent.position, targetPosition, smoothSpeed);
                parent.position = new Vector3(smoothPosition.x, 7.27f, smoothPosition.z);
                transform.position = parent.position;

            }
            else
            {
                if (follow)
                {
                    realSpeed = Mathf.Lerp(realSpeed, (speed + acceleration), speed * 0.95f / 500);
                    realSpeed = speed + acceleration;
                    Vector3 a = parent.right;
                    parent.position = new Vector3(parent.position.x + Time.deltaTime * a.x * realSpeed, 7.27f, parent.position.z + Time.deltaTime * a.z * realSpeed);
                    targetPosition = player.position + offset;
                    Vector3 smoothPositionz = Vector3.Lerp(parent.position, targetPosition, smoothSpeed);
                    Vector3 smoothPositionx = Vector3.Lerp(parent.position, Frog.nextPos + offset, smoothSpeed / 10);

                    parent.position = new Vector3(smoothPositionx.x, 7.27f, smoothPositionz.z);

                    transform.position = parent.position;

                }
                else
                {
                    targetPosition = player.position + offset;

                    Vector3 smoothPositionz = Vector3.Lerp(parent.position, targetPosition, smoothSpeed);
                    parent.position = new Vector3(parent.position.x, 7.27f, smoothPositionz.z);

                }
            }
        }
        else
        {
            if (FrogCentral.frog != null)
            {
                player = FrogCentral.frog.transform;

            }
        }
    }
    public void ForceMovement()
    {
        targetPosition = player.position + offset;
        Vector3 smoothPositionx = Frog.nextPos + offset;
        parent.position = new Vector3(smoothPositionx.x, parent.position.y, targetPosition.z);
    }

    public void PvPForceMovement()
    {
        targetPosition = cameraStartPos.position + offset;
        parent.position = new Vector3(targetPosition.x, parent.position.y, targetPosition.z);
        FrogCentral.frog.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnEnable()
    {
        FrogController.OnFroggoJump += Follow;
        FrogController.OnFroggoLand += StopFollow;
    }
    private void OnDisable()
    {
        FrogController.OnFroggoJump -= Follow;
        FrogController.OnFroggoLand -= StopFollow;

    }

    void Follow()
    {
        follow = true;
    }

    void StopFollow()
    {
        follow = false;
    }
}