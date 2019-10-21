using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasketBallControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _basketBall;

    [SerializeField]
    private Transform _basPosition;

    [SerializeField]
    private Slider _energy;

    Rigidbody _rig;
    private float speedy;
    private float speedz;

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    speedy = Random.Range(180f, 210f);
        //    speedz = Random.Range(180f, 210f);
        //    GameObject go= Instantiate(basketBall, bas.position, Quaternion.identity) as GameObject;
        //    //g.transform.parent = bas.transform;
        //    g = go.GetComponent<Rigidbody>();
        //    g.velocity = new Vector3(0, speedy, speedz);
        //    Destroy(go, 30f);
        //}


        //手机触摸
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                speedy += Time.deltaTime * 20;
                speedz += Time.deltaTime * 20;

                _energy.value += Time.deltaTime / 4.5f;
                if (_energy.value >= 1)
                {
                    _energy.value = 1;
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                GameObject go = Instantiate(_basketBall, _basPosition.position, Quaternion.identity) as GameObject;
                _rig = go.GetComponent<Rigidbody>();
                _rig.velocity = new Vector3(0, speedy, speedz);
                speedy = 0f;
                speedz = 0f;
                _energy.value = 0;
                Destroy(go, 20f);
            }
        }

        //鼠标点击
        //if (Input.GetMouseButton(0))
        //{
        //    speedy += Time.deltaTime * 40;
        //    speedz += Time.deltaTime * 40;

        //    _energy.value += Time.deltaTime / 4.5f;
        //    if (_energy.value >= 1)
        //    {
        //        _energy.value = 1;
        //    }
        //    //print(speedy);
        //}

        //else if (Input.GetMouseButtonUp(0))
        //{
        //    GameObject go = Instantiate(_basketBall, _basPosition.position, Quaternion.identity) as GameObject;
        //    _rig = go.GetComponent<Rigidbody>();
        //    _rig.velocity = new Vector3(0, speedy, speedz);
        //    speedy = 0f;
        //    speedz = 0f;
        //    _energy.value = 0;
        //    Destroy(go, 20f);
        //}
    }
}
