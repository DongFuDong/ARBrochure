using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARPaint : MonoBehaviour
{
    //[SerializeField]
    //private GameObject ARCamera;
    //[SerializeField]
    //private Material material;


    //private Vuforia.Image image;

    //private Texture2D text;
    //private byte[] buff = null;
    //private float width;
    //private float height;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    text = (Texture2D)Vuforia.VuforiaRenderer.Instance.VideoBackgroundTexture;
    //    material = GetComponent<Renderer>().material;
    //    material.mainTexture = text;
    //}
    //private void Update()
    //{
    //    if(Vuforia.VuforiaRenderer.Instance != null)
    //    {
    //        if(Vuforia.VuforiaRenderer.Instance.VideoBackgroundTexture != null)
    //        {
    //            text = (Texture2D)Vuforia.VuforiaRenderer.Instance.VideoBackgroundTexture;
    //            buff = text.GetRawTextureData();
    //            width = text.width;
    //            height = text.height;
    //        }
    //    }
    //}

    //Model duck
    [SerializeField]
    public GameObject Duck;

    private Texture2D texture;

    private int screenWidth;
    //保存屏幕宽度
    private int screenHeight;
    //保存屏幕高度

    //拾取真正贴图的四个点的坐标
    Vector3 targetAnglePoint1;//左上角坐标
    Vector3 targetAnglePoint2;//左下角坐标
    Vector3 targetAnglePoint3; //右上角坐标  
    Vector3 targetAnglePoint4; //右下角坐标

    public GameObject plane;
    //储存确定贴图大小的面片物体

    Vector2 halfSize;
    //记录plane宽高的一半值


    void Start()
    {
        screenWidth = Screen.width;
        //屏幕宽
        screenHeight = Screen.height;
        //屏幕高

        texture = new Texture2D(screenWidth, screenHeight, TextureFormat.RGB24, false);//实例化空纹理
    }


    //截屏函数
    public void ScreenShot()
    {
        texture.ReadPixels(new Rect(0, 0, screenWidth, screenHeight), 0, 0);
        //读取屏幕像素信息
        texture.Apply();
        //存储为纹理数据

        halfSize = new Vector2(plane.GetComponent<MeshFilter>().mesh.bounds.size.x, plane.GetComponent<MeshFilter>().mesh.bounds.size.z) * 50.0f * 0.5f;
        //获取Plane的长宽的一半值

        //确定真实贴图的世界坐标
        targetAnglePoint1 = transform.parent.position + new Vector3(-halfSize.x, 0, halfSize.y);
        targetAnglePoint2 = transform.parent.position + new Vector3(-halfSize.x, 0, -halfSize.y);
        targetAnglePoint3 = transform.parent.position + new Vector3(halfSize.x, 0, halfSize.y);
        targetAnglePoint4 = transform.parent.position + new Vector3(halfSize.x, 0, -halfSize.y);

        //获取VP值
        Matrix4x4 P = GL.GetGPUProjectionMatrix(Camera.main.projectionMatrix, false);
        Matrix4x4 V = Camera.main.worldToCameraMatrix;
        Matrix4x4 VP = P * V;

        //给鸭子的Shader传递贴图四个点的世界坐标，VP，以及贴图
        Duck.GetComponent<Renderer>().material.SetVector("_Uvpoint1", new Vector4(targetAnglePoint1.x, targetAnglePoint1.y, targetAnglePoint1.z, 1f));
        Duck.GetComponent<Renderer>().material.SetVector("_Uvpoint2", new Vector4(targetAnglePoint2.x, targetAnglePoint2.y, targetAnglePoint2.z, 1f));
        Duck.GetComponent<Renderer>().material.SetVector("_Uvpoint3", new Vector4(targetAnglePoint3.x, targetAnglePoint3.y, targetAnglePoint3.z, 1f));
        Duck.GetComponent<Renderer>().material.SetVector("_Uvpoint4", new Vector4(targetAnglePoint4.x, targetAnglePoint4.y, targetAnglePoint4.z, 1f));
        Duck.GetComponent<Renderer>().material.SetMatrix("_VP", VP);
        Duck.GetComponent<Renderer>().material.mainTexture = texture;
    }
}
