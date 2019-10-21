using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour
{
    public Camera cam;
    private Vector3 _vec3TargetScreenSpace;// 目标物体的屏幕空间坐标  
    private Vector3 _vec3TargetWorldSpace;// 目标物体的世界空间坐标 
    private Transform _trans;// 目标物体的空间变换组件  
    private Vector3 _vec3MouseScreenSpace;// 鼠标的屏幕空间坐标  
    private Vector3 _vec3Offset;// 偏移  

    void Awake() { _trans = this.transform; }

    IEnumerator OnMouseDown()

    {
        print("click");
        Config.isScale = false;
        Config.isRoate = true;
        // 把目标物体的世界空间坐标转换到它自身的屏幕空间坐标  

        _vec3TargetScreenSpace = cam.WorldToScreenPoint(_trans.position);

        // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   

        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

        // 计算目标物体与鼠标物体在世界空间中的偏移量   

        _vec3Offset = _trans.position - cam.ScreenToWorldPoint(_vec3MouseScreenSpace);

        // 鼠标左键按下   

        while (Input.GetMouseButton(0))
        {
            //住摄像机向鼠标位置发射射线  
            Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit mHit;
            //射线检验  
            if (Physics.Raycast(mRay, out mHit))
            {
                if (mHit.collider.gameObject.tag == "Model")
                {
                    print("move");
                    // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  

                    _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

                    // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  

                    _vec3TargetWorldSpace = cam.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

                    // 更新目标物体的世界空间坐标   

                    _trans.position = _vec3TargetWorldSpace;

                    // 等待固定更新   
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }
    void OnMouseExit()
    {
        Config.isScale = true;
        Config.isRoate = false;
    }

    //void Update()
    //{
    //    if (Input.touchCount == 1)
    //    {
    //        //住摄像机向鼠标位置发射射线  
    //        Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //        RaycastHit mHit;
    //        //射线检验  
    //        if (Physics.Raycast(mRay, out mHit))
    //        {
    //            if (mHit.collider.gameObject.tag == "Model")
    //            {
    //                if (Input.GetTouch(0).phase == TouchPhase.Began)
    //                {
    //                    print("click");
    //                    Config.isScale = false;
    //                    Config.isRoate = true;
    //                    // 把目标物体的世界空间坐标转换到它自身的屏幕空间坐标          
    //                    _vec3TargetScreenSpace = cam.WorldToScreenPoint(_trans.position);
    //                    // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   
    //                    _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);
    //                    // 计算目标物体与鼠标物体在世界空间中的偏移量   
    //                    _vec3Offset = _trans.position - cam.ScreenToWorldPoint(_vec3MouseScreenSpace);
    //                }
    //                if (Input.GetTouch(0).phase == TouchPhase.Moved)
    //                {
    //                    // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  

    //                    _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

    //                    // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  

    //                    _vec3TargetWorldSpace = cam.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

    //                    // 更新目标物体的世界空间坐标   

    //                    _trans.position = _vec3TargetWorldSpace;

    //                }
    //            }
    //        }
        //}
    //}
}