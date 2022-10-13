using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvavidasController : MonoBehaviour
{
    public static GameObject spawnPos;
    private void Awake()
    {
        spawnPos = this.gameObject;
    }
    void ChangePosition()
    {
        spawnPos.transform.position = FrogController.playerPos;
    }

    private void OnEnable()
    {
        FrogController.OnFroggoLand += ChangePosition;
    }

    private void OnDisable()
    {
        FrogController.OnFroggoLand -= ChangePosition;
    }
}
