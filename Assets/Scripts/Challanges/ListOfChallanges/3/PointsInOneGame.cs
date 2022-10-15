using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsInOneGame : Challange
{
    [SerializeField] float points;

    private void OnEnable()
    {
            FrogController.OnFroggoLand += Validate;

    }
    private void Start()
    {
        quest = UIController.instance.slotQuest_3;

    }
    private void OnDisable()
    {
            FrogController.OnFroggoLand -= Validate;

    }
    public override void Validate()
    {

        if (!completed)
        {
            if (Points.distanceUnit >= points)
            {

                Complete();
                FrogController.OnFroggoLand -= Validate;
            }
        }
        

    }
}
