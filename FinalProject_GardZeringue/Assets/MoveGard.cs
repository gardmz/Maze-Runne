using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGard : MonoBehaviour
{
    Animator anim;
    public GameObject ForwardView, BirdsEyeViewer, FlashLight;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float y = 0.0f;
    public float x = 0.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        ForwardView = GameObject.Find("ForwardView");
        BirdsEyeViewer = GameObject.Find("BirdsEyeView");
        FlashLight = GameObject.Find("SpotLight");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
            anim.SetBool("jump", false);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("LeftRight", h);
        anim.SetFloat("ForwardBackward", v);

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (ForwardView.GetComponent<Camera>().enabled)
            {
                ForwardView.GetComponent<Camera>().enabled = false;
                BirdsEyeViewer.GetComponent<Camera>().enabled = true;
            }
            else
            {
                ForwardView.GetComponent<Camera>().enabled = true;
                BirdsEyeViewer.GetComponent<Camera>().enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashLight.GetComponent<Light>().enabled)
            {
                FlashLight.GetComponent<Light>().enabled = false;
            }
            else
                FlashLight.GetComponent<Light>().enabled = true;
        }

        if (Input.GetMouseButton(1))
        {
            y += speedH * Input.GetAxis("Mouse X");
            x -= speedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(0.0f, y, 0.0f);
        }
    }
}
