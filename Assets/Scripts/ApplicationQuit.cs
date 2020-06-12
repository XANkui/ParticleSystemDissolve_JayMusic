using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public UnityAndroidManagerCC mUnityAndroidManagerCC;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    void Init()
    {

        mUnityAndroidManagerCC.VulumeReduceKeyDownCallback += () =>
        {
            Application.Quit();
        };
    }
}
