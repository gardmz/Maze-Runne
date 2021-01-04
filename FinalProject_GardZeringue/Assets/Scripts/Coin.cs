using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 pos;
    Coin coin;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(Random.Range(0f, 100f), 0, Random.Range(0f, 1000f));
        Instantiate(coin,pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
