using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTracer : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        FindClosetCoin();
    }
    void FindClosetCoin()
    {
        float disToClosestCoin = Mathf.Infinity;
        Coin closestCoin = null;
        Coin[] allCoins = GameObject.FindObjectsOfType<Coin>();

        foreach(Coin c in allCoins)
        {
            float distanceToCoin = (c.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToCoin < disToClosestCoin)
            {
                disToClosestCoin = distanceToCoin;
                closestCoin = c;
            }
        }
        transform.LookAt(closestCoin.transform.position);
    }
}
