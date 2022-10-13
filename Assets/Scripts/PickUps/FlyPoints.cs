using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPoints : MonoBehaviour
{
    public delegate void squashedFly();
    public static event squashedFly OnFlySquashed;
    [SerializeField] int flyValue;
    static int flies;

    void Start()
    {
        flies = PlayerPrefs.GetInt("Coins");
       // FlyManager.count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddPoints(flyValue);
            Pointss();
            PickUp();
        }
    }
    public static void AddPoints(int flyPoint)
    {
        FlyManager.count += flyPoint;
        flies += FlyManager.count;
        OnFlySquashed();


    }

    public void Pointss()
    {
        PlayerPrefs.SetInt("Coins",flies);
    }

    private void PickUp()
    {
        Invoke("RespawnPickUp", 20);
        gameObject.SetActive(false);
    }

    private void RespawnPickUp()
    {
        gameObject.SetActive(true);
    }
}
