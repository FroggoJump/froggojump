using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInOneGame : Challange
{
    [SerializeField] float jumps;

    private void OnEnable()
    {
        
            FrogController.OnFroggoJump += Validate;

    }
    private void Start()
    {
        quest = UIController.instance.slotQuest_2;

    }
    private void OnDisable()
    {
        FrogController.OnFroggoJump -= Validate;

    }
    public override void Validate()
    {

        if (!completed)
        {
            if (PlayerStats.JumpAmount >= jumps)
            {

                Complete();
                FrogController.OnFroggoJump -= Validate;
            }
        }
      

    }
}
