using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityAndroidManagerCC : MonoBehaviour
{


    public Action VulumeAddKeyUpCallback;
    public Action VulumeAddKeyDownCallback;
    public Action VulumeReduceKeyUpCallback;
    public Action VulumeReduceKeyDownCallback;


    AndroidJavaObject jo;       // 设置 android java 实体

    public AndroidJavaObject Jo

    {

        get

        {   // jo 为空，就新建一个对应的 android java 实体

            if (jo == null)
            {

                AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

                jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

            }

            return jo;

        }



    }

    // Use this for initialization

    void Start()
    {

        // 使用 android java 实体Jo调用 测试函数

        //Jo.Call("ShowToast", new object[] { "调用android aar的ShowToast 函数" });

#if UNITY_EDITOR
#else
        Jo.Call("UnityCallAndroid");

        ReigisterListener();
#endif



    }




    void ReigisterListener() {
        Debug.Log("ReigisterListener....");

        jo.Call("SetVulumeAddKeyUpCallback",new object[] { this.gameObject.name, "SetVulumeAddKeyUpCallback" } );
        jo.Call("SetVulumeAddKeyDownCallback", new object[] { this.gameObject.name, "SetVulumeAddKeyDownCallback" });
        jo.Call("SetVulumeReduceKeyUpCallback", new object[] { this.gameObject.name, "SetVulumeReduceKeyUpCallback" });
        jo.Call("SetVulumeReduceKeyDownCallback", new object[] { this.gameObject.name, "SetVulumeReduceKeyDownCallback" });
    }


    private void SetVulumeAddKeyUpCallback(string ss) {
        Debug.Log("音量键 + 抬起 "+ss);
        isVulumeAddKeyDow = false;
        if (VulumeAddKeyUpCallback != null) {
            VulumeAddKeyUpCallback();
        }
    }

    bool isVulumeAddKeyDow = false;
    private void SetVulumeAddKeyDownCallback(string ss)
    {
        

        if (VulumeAddKeyDownCallback != null && isVulumeAddKeyDow ==false)
        {
            Debug.Log("音量键 + 按下");

            VulumeAddKeyDownCallback();
        }

        isVulumeAddKeyDow = true;
    }

    private void SetVulumeReduceKeyUpCallback(string ss)
    {
        Debug.Log("音量键 - 抬起");
        isVulumeReduceKeyDown = false;
        if (VulumeReduceKeyUpCallback != null)
        {
            VulumeReduceKeyUpCallback();
        }
    }

    bool isVulumeReduceKeyDown = false;

    private void SetVulumeReduceKeyDownCallback(string ss)
    {
        
        if (VulumeReduceKeyDownCallback != null && isVulumeReduceKeyDown == false)
        {
            Debug.Log("音量键 - 按下");
            VulumeReduceKeyDownCallback();
        }

        isVulumeReduceKeyDown = true;
    }
}
