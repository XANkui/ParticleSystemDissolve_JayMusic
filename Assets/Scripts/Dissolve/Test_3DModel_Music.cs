using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_3DModel_Music : MonoBehaviour
{
    public GameObject ds_1;
    public GameObject ds_2;
    public GameObject ds_3;
    public GameObject ds_4;
    public GameObject ds_5;
    public GameObject ds_6;
    public GameObject ds_7;
    public GameObject ds_8;
    public GameObject ds_9;
    public GameObject ds_10;
    public GameObject ds_11;
    public GameObject ds_12;

    public AudioSource audioS;


    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    int addtime = 1500;

    void PlayMusic()
    {
        audioS.Play();
    }

    void init()
    {

        #region 播放音乐

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            PlayMusic();

        },

#if UNITY_EDITOR
        9000
#else   // 我们的机器音频会慢约一秒
        9000 - 1000
#endif

        , 1);

#endregion


#region 歌名

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_1, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_1);


            }, 3300, 1);


        }, 1000, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_2, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_2);
            }, 3300, 1);

        }, 3500, 1);

#endregion



#region 02
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_3, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_3);
            }, 3000, 1);

        }, 7500, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_4, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_4);
            }, 3000, 1);

        }, 9000, 1);


        //TimerTaskSystem.Instance.AddTimerTask(() =>
        //{
        //    SetActiveGo(ds_12, true);
        //    TimerTaskSystem.Instance.AddTimerTask(() =>
        //    {
               
        //    }, 3000, 1);

        //}, 9400, 1);



        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_5, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_5);
            }, 3000, 1);

        }, 12500, 1);
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_6, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_6);
            }, 3000, 1);

        }, 15200, 1);

#endregion




#region 03

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_7, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
               TimeListenerEffect(ds_7);
            }, 3000, 1);

        }, 18700, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_8, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_8);
            }, 3000, 1);

        }, 21200 - 500, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_9, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_9);
            }, 3000, 1);

        }, 23200, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_10, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_10);
            }, 3000, 1);

        }, 25700 - 2000, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_11, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                TimeListenerEffect(ds_11);
            }, 3000, 1);

        }, 30200 - 2500, 1);
#endregion

    }



    // Update is called once per frame
    void Update()
    {

    }

    void SetActiveGo(GameObject go, bool isActive)
    {

        go.SetActive(isActive);

    }


    private void TimeListenerEffect( GameObject go) {
        MeshRenderer[] meshList = go.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer item in meshList)
        {
            // 动画有 MeshRenderer 显隐，所以动画也要关闭
            if (go.GetComponent<Animation>() != null)
            {
                go.GetComponent<Animation>().Stop();
            }
            

            item.enabled = false;
        }

        Transform pses = go.transform.Find("Ps");

        for (int i = 0; i < pses.childCount; i++)
        {
            Transform item = pses.GetChild(i);
            item.gameObject.SetActive(true);
            item.gameObject.SetActive(true);
            item.gameObject.GetComponent<ParticleSystem>().Play();
            item.gameObject.GetComponent<ParticleSystem>().Play();
        }

       
    }
}
