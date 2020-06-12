using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(TimerTaskSystem))]
public class Test : MonoBehaviour
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
    public GameObject ds_13;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    int addtime = 1500;

    void init() {
        TimerTaskSystem.Instance.AddTimerTask(()=>{
            SetActiveGo(ds_1,true);
            TimerTaskSystem.Instance.AddTimerTask(()=> {
                ds_1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_1.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 300, 1);


        }, 1000 , 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_2, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_2.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 500, 1);

        }, 2000 + addtime, 1);
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_3, true);

        }, 3000 + addtime*2, 1);
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_4, true);

        }, 4000 + addtime*3, 1);
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_5, true);

        }, 5000 + addtime*4, 1);
        TimerTaskSystem.Instance.AddTimerTask(() => {
            SetActiveGo(ds_6, true);

        }, 6000 + addtime*5, 1);
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_7, true);

        }, 7000 + addtime*6, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_8, true);

        }, 8000 + addtime*7, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_9, true);

        }, 9000 + addtime*8, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_10, true);

        }, 10000 + addtime*9, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_11, true);

        }, 11000 + addtime*10, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_12, true);

        }, 12000 + addtime*11, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_13, true);

        }, 13000 + addtime*12, 1);

    }

    void setTimeTask() {
        for (int i =1; i<14; i++)
        {
            string goName = "ds_" + "i";

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                SetActiveGo(ds_1, true);

            }, 1000, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetActiveGo(GameObject go, bool isActive) {
        
            go.SetActive(isActive);
        
    }
}
