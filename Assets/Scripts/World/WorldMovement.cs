using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public bool inverted;
    private void Update()
    {
        if (!inverted)
        {
            transform.position -= SpeedController.Move;

        }
        else
        {
            transform.position += SpeedController.Move;
        }
    }
}
