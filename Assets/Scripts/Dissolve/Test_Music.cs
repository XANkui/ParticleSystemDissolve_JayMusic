using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Music : MonoBehaviour
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

    void PlayMusic() {
        audioS.Play();
    }

    void init()
    {

        #region 播放音乐

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            PlayMusic();

        }, 9000 - 1000, 1);

        #endregion


        #region 歌名

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_1, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_1.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3300, 1);


        }, 1000, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_2, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_2.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3300, 1);

        }, 3500, 1);

        #endregion



        #region 02
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_3, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_3.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_3.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 7500, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_4, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_4.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_4.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 9000, 1);


        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_12, true);
            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_12.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_12.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 9400, 1);



        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_5, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_5.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_5.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 12500, 1);
        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_6, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_6.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_6.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 15200, 1);

        #endregion




        #region 03

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_7, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_7.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_7.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 18700, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_8, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_8.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_8.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 21200-500, 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_9, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_9.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_9.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 23200 , 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_10, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_10.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_10.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 25700-2000 , 1);

        TimerTaskSystem.Instance.AddTimerTask(() =>
        {
            SetActiveGo(ds_11, true);

            TimerTaskSystem.Instance.AddTimerTask(() =>
            {
                ds_11.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject ps = ds_11.transform.GetChild(0).gameObject;
                ps.SetActive(true);
                ps.GetComponent<ParticleSystem>().Play();
            }, 3000, 1);

        }, 30200-2500, 1);
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
}
