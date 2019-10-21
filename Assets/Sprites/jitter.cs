using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jitter : MonoBehaviour
{
    private float lastX;
    private float lastY;
    private float lastZ;

    private void Start()
    {
        lastX = this.transform.position.x;
        lastY = this.transform.position.y;
        lastZ = this.transform.position.z;
    }
    protected  void Update()
    {
        //关键，当模型抖动超过一定范围时，不修正模型的坐标角度，记录坐标和角度
        if (((Math.Abs(this.transform.position.x - lastX) > 0.05 || Math.Abs(this.transform.position.y - lastY) > 0.05 || Math.Abs(this.transform.position.z - lastZ) > 0.05)))
        {
            this.transform.position = new Vector3(lastX, lastY, lastZ);
        }
        else//模型抖动范围过小时，修正模型坐标为上一次正确的坐标
        {
            this.transform.position = new Vector3(lastX, lastY, lastZ);
        }
    }
}
