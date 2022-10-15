using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliesInOnePlay : Challange
{
    [SerializeField] float flies;

    private void OnEnable()
    {
        
            FlyPoints.OnFlySquashed += Validate;
    }
    private void Start()
    {
        quest = UIController.instance.slotQuest_1;

    }
    private void OnDisable()
    {
        FlyPoints.OnFlySquashed -= Validate;

    }
    public override void Validate()
    {

        if (!completed)
        {
            if (PlayerStats.EatenFlies >= flies)
            {

                Complete();
                FlyPoints.OnFlySquashed -= Validate;
            }
        }


    }
}
