using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchScaleObj : MonoBehaviour
{

    float x;
    float y;

    float speed = 2.5f;
    float speed1 = 80f;

    float oldScale;
    float newScale;
    Vector3 temp;

    Vector2 oldPosition1;
    Vector2 oldPosition2;

    //暂时不用
    //public Camera cam;
    //private Vector3 _vec3TargetScreenSpace;// 目标物体的屏幕空间坐标  
    //private Vector3 _vec3TargetWorldSpace;// 目标物体的世界空间坐标 
    //private Transform _trans;// 目标物体的空间变换组件  
    //private Vector3 _vec3MouseScreenSpace;// 鼠标的屏幕空间坐标  
    //private Vector3 _vec3Offset;// 偏移  

    //void Awake() { _trans = transform; }

    // Use this for initialization
    void Start()
    {
        oldScale = this.transform.localScale.x;
        temp = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {


        //旋转
        if (Config.isScale)
        {

            //测试
            if (Input.GetMouseButton(0))
            {

                //x = Input.GetAxis("Mouse X") * speed;
                //y = Input.GetAxis("Mouse Y") * speed;

                ////temp.x += y;
                ////temp.y -= x;
                //temp = new Vector3(0, -x);
                ////this.transform.eulerAngles = temp;

                //this.transform.Rotate(temp, Space.World);


                x = Input.GetAxis("Mouse X") * speed1;
                y = Input.GetAxis("Mouse Y") * speed1;
                this.transform.Rotate(Vector3.up * -x * Time.deltaTime, Space.Self);
               // this.transform.Rotate(Vector3.left * y * Time.deltaTime, Space.Self);

            }


            //单点触摸旋转
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    //x = Input.GetAxis("Mouse X") * speed;
                    //y = Input.GetAxis("Mouse Y") * speed;

                    //temp.x += y;
                    //temp.y -= x;

                    //this.transform.eulerAngles = temp;

                    x = Input.GetAxis("Mouse X") * speed1;
                    y = Input.GetAxis("Mouse Y") * speed1;
                    //this.transform.Rotate(Vector3.up * -x * Time.deltaTime, Space.Self);
                    this.transform.Rotate(Vector3.up * y * Time.deltaTime, Space.Self);

                }
                //if ((Input.GetTouch(0).phase == TouchPhase.Stationary && Input.GetTouch(1).phase==TouchPhase.Moved) && Config.isRoate)
                //{
                //    x = Input.GetAxis("Mouse X") * speed;
                //    y = Input.GetAxis("Mouse Y") * speed;

                //    //Touch touch = Input.GetTouch(0);
                //    //Vector2 delatPos = touch.deltaPosition;

                //    temp.x += y;
                //    temp.y -= x;

                //    this.transform.eulerAngles = temp;

                //    //this.transform.Rotate(Vector3.up * -x * Time.deltaTime, Space.World);
                //    //this.transform.Rotate(Vector3.right * y * Time.deltaTime, Space.World);
                //}
            }


            //两指缩放
            if (Input.touchCount > 1 && !Config.isRoate)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
                {

                    //保存临时触摸点的位置
                    Vector2 tempPosition1 = Input.GetTouch(0).position;
                    Vector2 tempPosition2 = Input.GetTouch(1).position;
                    //oldScale += Input.GetAxis("Mouse ScrollWheel");
                    if (isEnglarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
                    {
                        //fangda
                        oldScale = transform.localScale.x;
                        newScale = 1.025f * oldScale;
                        this.transform.localScale = new Vector3(1, 1, 1) * newScale;

                    }
                    else
                    {
                        //suoxiao
                        oldScale = transform.localScale.x;
                        newScale = oldScale / 1.025f;
                        this.transform.localScale = new Vector3(1, 1, 1) * newScale;

                    }

                    oldPosition1 = tempPosition1;
                    oldPosition2 = tempPosition2;

                }

            }
        }
    }
    //判断手势是否是放大或缩小
    bool isEnglarge(Vector2 op1, Vector2 op2, Vector2 np1, Vector2 np2)
    {
        float leng1 = Mathf.Sqrt((op1.x - op2.x) * (op1.x - op2.x) + (op1.y - op2.y) * (op1.y - op2.y));
        float leng2 = Mathf.Sqrt((np1.x - np2.x) * (np1.x - np2.x) + (np1.y - np2.y) * (np1.y - np2.y));

        if (leng1 < leng2)
        {
            return true;
        }

        else
        {
            return false;
        }

    }


    //暂时不用
    //void Drag()
    //{
    //    if (Input.touchCount == 1)
    //    {
    //        if (Input.GetTouch(0).phase == TouchPhase.Began)
    //        {
    //            print("click");
    //            Config.isScale = false;
    //            Config.isRoate = true;
    //            // 把目标物体的世界空间坐标转换到它自身的屏幕空间坐标  

    //            _vec3TargetScreenSpace = cam.WorldToScreenPoint(_trans.position);

    //            // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   

    //            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

    //            // 计算目标物体与鼠标物体在世界空间中的偏移量   

    //            _vec3Offset = _trans.position - cam.ScreenToWorldPoint(_vec3MouseScreenSpace);
    //        }

    //        if (Input.GetTouch(0).phase == TouchPhase.Moved)
    //        {
    //            // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  

    //            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

    //            // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  

    //            _vec3TargetWorldSpace = cam.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

    //            // 更新目标物体的世界空间坐标   

    //            _trans.position = _vec3TargetWorldSpace;

    //        }
    //    }
    //}

    //void OnMouseExit()
    //{
    //    Config.isScale = true;
    //    Config.isRoate = false;
    //}

}
