using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    Canvas CanvasInstructions, CanvasCoins;
    MoveGard moveScript;
    static bool InstructionsShowing;
    public Text coinsCurr;
    public int cur_coins = 0;
    public int max_coins = 0;
    public GameObject Door;

    LightTracer light;
  
    void Start()
    {
        CanvasInstructions = GameObject.Find("CanvasInstructions").GetComponent<Canvas>();
        CanvasCoins = GameObject.Find("CanvasCoins").GetComponent<Canvas>();
        moveScript = GameObject.Find("Gard").GetComponent<MoveGard>();
        light = GameObject.Find("SpotLight").GetComponent<LightTracer>();

        Door.SetActive(false);
        max_coins = cur_coins;
        UpdateUI();
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (InstructionsShowing)
            {
                InstructionsShowing = false;
                CanvasInstructions.enabled = false;
                CanvasCoins.enabled = true;
                moveScript.enabled = true;
            }
            else
            {
                InstructionsShowing = true;
                CanvasInstructions.enabled = true;
                CanvasCoins.enabled = false;
                moveScript.enabled = false;
            }
        }
        if (Door.activeSelf)
        {
            light.transform.LookAt(Door.transform.position);
        }
    }

    public void UpdateUI()
    {
        if (cur_coins > 0)
        {
            coinsCurr.text = "Coins Left: " + cur_coins;
        }
        else if (cur_coins <= 0)
        {
            coinsCurr.text = "All Coins Collected, Locate The Escape Portal!";
            
            Door.SetActive(true);
        }
    }
}
