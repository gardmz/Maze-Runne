using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntrusctionsForLevel3 : MonoBehaviour
{
    Canvas CanvasInstructions, CanvasCoins;
    MoveGard moveScript;
    static bool InstructionsShowing;

    //
    public Text coinsCurr;
    public int cur_coins = 0;
    public int max_coins = 0;
    public GameObject Doorlvl3;
    //
    LightTracer light;
    // Start is called before the first frame update
    void Start()
    {
        CanvasInstructions = GameObject.Find("CanvasInstructions").GetComponent<Canvas>();
        CanvasCoins = GameObject.Find("CanvasCoins").GetComponent<Canvas>();
        moveScript = GameObject.Find("Gard").GetComponent<MoveGard>();
        light = GameObject.Find("SpotLight").GetComponent<LightTracer>();

        //
        Doorlvl3.SetActive(false);
        max_coins = cur_coins;
        UpdateUI();
        //

    }

    // Update is called once per frame
    void Update()
    {
        //H will serve as the hotkey for our help menu 
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
        if (Doorlvl3.activeSelf)
        {
            light.transform.LookAt(Doorlvl3.transform.position);
        }
    }

    //
    public void UpdateUI()
    {
        if (cur_coins > 0)
        {
            coinsCurr.text = "Coins Left: " + cur_coins;
        }
        else if (cur_coins <= 0)
        {
            coinsCurr.text = "All Coins Collected, Locate The Escape Portal!";
            Doorlvl3.SetActive(true);
        }
    }
    //
}
