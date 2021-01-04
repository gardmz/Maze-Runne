using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{

    Instructions coinUI;
    private float rotateSpeed = 4f;
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset;
    Vector3 tempPos;

    void Awake()
    {
        coinUI = GameObject.Find("InstructionsInterface").GetComponent<Instructions>();
        coinUI.cur_coins++;
        posOffset = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.left * rotateSpeed);

        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            coinUI.cur_coins--;
            coinUI.UpdateUI();
        }
    }
}
