using System;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventSystem : MonoBehaviour
{
    [Serializable] public class onClicked : UnityEvent { }

    public onClicked onLeftClicked;
    public onClicked onRightClicked;
}
