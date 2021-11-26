using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnClicked();

    public event OnClicked onLeftClicked;
    public event OnClicked onRightClicked;

    public void PrintRight()
    {
        Debug.Log("Right");
    }

    public void PrintLeft()
    {
        Debug.Log("Left");
    }


    void Start()
    {
        onLeftClicked += PrintLeft;
        onRightClicked += PrintRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onLeftClicked();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            onRightClicked();
        }
    }
}
