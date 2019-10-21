using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject plane;

    private void Update()
    {
        //获取相机图像
        Matrix4x4 P = GL.GetGPUProjectionMatrix(Camera.main.projectionMatrix, false);
        //相机位置
       // Matrix4x4 V = Camera.main
    }
}
