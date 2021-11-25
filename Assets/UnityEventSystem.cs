using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventSystem : MonoBehaviour
{
    [Serializable] public class OnClicked: UnityEvent { }

    public OnClicked onLeftClicked;
    public OnClicked onRightClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onLeftClicked.Invoke();
        }

        else if (Input.GetMouseButtonDown(1))
        {
            onRightClicked.Invoke();
        }
    }
}
