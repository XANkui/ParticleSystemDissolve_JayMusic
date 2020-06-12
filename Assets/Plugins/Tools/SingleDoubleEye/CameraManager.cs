using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CameraManager : MonoBehaviour {


    [SerializeField] private Transform player;//玩家
    [SerializeField] Camera VuforiaCamera;// 
    [Header("双眼")]  

    [SerializeField] Transform doubleEyesContainer;

    [SerializeField] Camera cameraLeft;//camera
    [SerializeField] Transform TwoEyeCenter;//两眼中心点
    [SerializeField] Camera cameraRight;//camera




    [Header("单眼")]

    [SerializeField] Transform singeEyesContainer;
    [SerializeField] Camera camera;//camera//单眼

    [Range(10, 40)]
    private float fov = 60;
    public float Fov {
        get => fov;
        set {
            fov = value;
            fov_txt.text = value.ToString();

        }
    }
    public Slider slider;
    public void sliderFov(float value) {
        Fov = value;
    }

    public Text fov_txt;   
    public InputField fov_inputField;
    public Button fov_btn;
    public void fov_Btn_onClick() {
        Fov = float.Parse(fov_inputField.text);
        slider.value = Fov;
    }

    // Use this for initialization
    private Transform BackgroundPlane;
    private Vector3 BackgroundPlaneLocalPosition;
    private Quaternion BackgroundPlaneLocalQuaternion;
    private Boolean single = false;//是否是单眼
    private float fovPercent = 1;
    private Rect storeRect;
    private Vector3 initVector;
    private float defaultFov = 60;
    private float nearClipPlane = 0.25f;
    private float farClipPlane = 10000;

    

    void Start ()
    {
      //  initVector = - player.position + camera.transform.position;
        defaultFov = VuforiaCamera.fieldOfView;
        // vuforiaCamera.GetComponent<Camera>().enabled = (false);

        slider.onValueChanged.AddListener(sliderFov);
    }
	
	// Update is called once per frame
	void Update () {
        player.position = VuforiaCamera.transform.position;
        player.rotation = VuforiaCamera.transform.rotation;
        UpdateLogic(VuforiaCamera);
	}

    internal void UpdateLogic(Camera vuforiaCamera)
    {
        //显示fov的值
       // fov.text = vuforiaCamera.fieldOfView + "";
        //显示fov的percent值
       // fovPercentText.text = fovPercent + "," + (int)(vuforiaCamera.fieldOfView * fovPercent);
        //因我们使用双眼的原因，所以我们不能使用ARCamera，为了将背景图始终能被我们的camera看见，这里当发现vuforia创建了BackgroundPlane的时候，将它的父节点设置为我们的camera
        storeRect = new Rect(vuforiaCamera.rect);

        singeEyesContainer.gameObject.SetActive(true);
        doubleEyesContainer.gameObject.SetActive(true);
        if (BackgroundPlane == null)
        {
            BackgroundPlane = vuforiaCamera.transform.Find("BackgroundPlane");
            BackgroundPlane.gameObject.SetActive(false);
        }
        //Debug.Log("BackgroundPlaneLocalPosition = " + (BackgroundPlaneLocalPosition == null));
        //Debug.Log("BackgroundPlane.localPosition.Equals(Vector3.zero) = " + BackgroundPlane.localPosition.Equals(Vector3.zero));
        if (BackgroundPlaneLocalPosition.Equals(Vector3.zero) && !BackgroundPlane.localPosition.Equals(Vector3.zero))
        {

            Debug.Log("BackgroundPlane.localPosition = " + BackgroundPlane.localPosition);
            BackgroundPlaneLocalPosition = BackgroundPlane.localPosition;
            BackgroundPlaneLocalQuaternion = BackgroundPlane.localRotation;

            Debug.Log("BackgroundPlaneLocalPosition = " + BackgroundPlaneLocalPosition);
        }

        if (single)
        {
            //隐藏双眼
            doubleEyesContainer.gameObject.SetActive(false);
            SingleEye(vuforiaCamera);
        }
        else
        {
            //隐藏单眼
            singeEyesContainer.gameObject.SetActive(false);
            DoubleEye(vuforiaCamera);
        }


        //if (BackgroundPlane != null) {
        //    BackgroundPlane.gameObject.SetActive(false);
        //}
    }

    private void SingleEye(Camera vuforiaCamera)
    {

        if (BackgroundPlane != null)
        {
            BackgroundPlane.parent = camera.transform;
            //  BackgroundPlane.localPosition = BackgroundPlaneLocalPosition;
            // BackgroundPlane.localRotation = BackgroundPlaneLocalQuaternion;

        }
        if (BackgroundPlaneLocalPosition != null)
        {
            BackgroundPlane.localPosition = BackgroundPlaneLocalPosition;
            BackgroundPlane.localRotation = BackgroundPlaneLocalQuaternion;
        }
        //camera.fieldOfView = vuforiaCamera.fieldOfView * fovPercent;
        camera.fieldOfView = 24;
        camera.nearClipPlane = vuforiaCamera.nearClipPlane;
        camera.nearClipPlane = nearClipPlane;

        camera.farClipPlane = vuforiaCamera.farClipPlane;
        camera.farClipPlane = farClipPlane;

    }
    private void DoubleEye(Camera vuforiaCamera)
    {

        if (BackgroundPlane != null)
        {
            BackgroundPlane.parent = TwoEyeCenter.transform;
            // BackgroundPlane.localPosition = BackgroundPlaneLocalPosition;
            //  BackgroundPlane.localRotation = BackgroundPlaneLocalQuaternion;
        }

        if (BackgroundPlaneLocalPosition != null)
        {
            BackgroundPlane.localPosition = BackgroundPlaneLocalPosition;
            BackgroundPlane.localRotation = BackgroundPlaneLocalQuaternion;
        }
        //cameraLeft.fieldOfView = vuforiaCamera.fieldOfView * fovPercent;
        //cameraLeft.fieldOfView = 24;
        //cameraLeft.fieldOfView = 54;
        cameraLeft.fieldOfView = Fov;
        cameraLeft.nearClipPlane = vuforiaCamera.nearClipPlane;
        cameraLeft.nearClipPlane =  nearClipPlane;
        
        cameraLeft.farClipPlane = vuforiaCamera.farClipPlane;
        cameraLeft.farClipPlane =  farClipPlane;

        //cameraRight.fieldOfView = vuforiaCamera.fieldOfView * fovPercent;
        //cameraRight.fieldOfView = 24;
        //cameraRight.fieldOfView = 54;
        cameraRight.fieldOfView = Fov;
        cameraRight.nearClipPlane = vuforiaCamera.nearClipPlane;
        cameraRight.nearClipPlane = nearClipPlane;

        cameraRight.farClipPlane = vuforiaCamera.farClipPlane;
        cameraRight.farClipPlane = farClipPlane;


        cameraLeft.rect = new Rect(storeRect.xMin, storeRect.yMin, storeRect.width / 2, storeRect.height);
        cameraLeft.aspect = 1f / (storeRect.width / 2f / storeRect.height);

        cameraRight.rect = new Rect(storeRect.xMin + storeRect.width / 2, storeRect.yMin, storeRect.width / 2, storeRect.height);
        cameraRight.aspect = 1f / (storeRect.width / 2f / storeRect.height);

        #if UNITY_EDITOR
        #else
        #endif

    }

    public void ChangeEyeCount()
    {
        single = !single;
    }

    public void OnSliderChange(float i)
    {
        fovPercent = i;
    }

    public void ShowHidePreview()
    {
        if (BackgroundPlane != null)
        {
            BackgroundPlane.gameObject.SetActive(!BackgroundPlane.gameObject.activeInHierarchy);
        }
    }


}
