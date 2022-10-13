using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCamera : MonoBehaviour
{
    public static Camera camera;
    private void Awake()
    {
        camera =Camera.main;
    }
}
