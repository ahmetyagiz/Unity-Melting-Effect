using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour //Delegate içine fonksiyon tutabilen yapýlardýr.
{
    public delegate void DelegateDebug();//Tanýmlama

    public DelegateDebug delegateDebug; //Obje oluþturma

    void Start()
    {
        //delegateDebug += Debug2; //Delegate içerisine fonksiyon ekleyebiliriz.
        //delegateDebug -= Debug2; //Delegate içerisinden fonksiyon çýkartabiliriz.
        
        AddMethod(Debug1); //Ekleme iþlemini method üzerinden de yapabiliriz
        RemoveMethod(Debug2); //Çýkarma iþlemini method üzerinden de yapabiliriz

        if (delegateDebug != null) //Nullcheck yapmazsak içi boþ olduðu için hata verir
        {
            delegateDebug();
        }
    }

    private void Debug1()
    {
        Debug.Log("Debug 1");
    }

    private void Debug2()
    {
        Debug.Log("Debug 2");
    }

    public void AddMethod(DelegateDebug method)
    {
        delegateDebug += method;
    }

    public void RemoveMethod(DelegateDebug method)
    {
        delegateDebug -= method;
    }
}
