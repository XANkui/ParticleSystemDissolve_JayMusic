using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimerTaskSystem))]
public class Test_TimerTaskSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // 任务 ID
    private int taskId;
    void Update()
    {

        #region 测试定时任务


        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("AddTimerTask");
            taskId = TimerTaskSystem.Instance.AddTimerTask(TestFunA, 1000, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("DeleteTimerTask " + taskId);
            TimerTaskSystem.Instance.DeleteTimerTask(taskId);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("ReplaceTimerTask " + taskId);
            TimerTaskSystem.Instance.ReplaceTimerTask(taskId, TestFunB, 500, 2);
        }
        #endregion

        #region 测试定时帧任务


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("AddTimerFrameTask");
            taskId = TimerTaskSystem.Instance.AddTimerFrameTask(TestFrameFunA, 50, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("DeleteTimerFrameTask " + taskId);
            TimerTaskSystem.Instance.DeleteTimerFrameTask(taskId);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("ReplaceTimerFrameTask " + taskId);
            TimerTaskSystem.Instance.ReplaceTimerFrameTask(taskId, TestFrameFunB, 500, 2);
        }
        #endregion

    }

    #region 测试用到的函数


    void TestFunA()
    {
        Debug.Log(" TestFunA taskId = " + taskId + "  " + System.DateTime.Now);
    }

    void TestFunB()
    {
        Debug.Log(" TestFunB taskId = " + taskId + "  " + System.DateTime.Now);
    }

    void TestFrameFunA()
    {
        Debug.Log(" TestFrameFunA taskId = " + taskId + "  " + System.DateTime.Now);
    }

    void TestFrameFunB()
    {
        Debug.Log(" TestFrameFunB taskId = " + taskId + "  " + System.DateTime.Now);
    }

    #endregion
}