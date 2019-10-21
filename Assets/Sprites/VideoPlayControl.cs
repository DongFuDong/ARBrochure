using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayControl : MonoBehaviour
{
    //[SerializeField]
    //private VideoPlayer _videoPlayer;
    ////[SerializeField]
    ////private string _name;
    //// Start is called before the first frame update
    //public int T => 1 + 2;
    //void Start()
    //{
    //   // _videoPlayer.url = "http://www.iqiyi.com/v_19rulyrdoc.html";
    //    _videoPlayer.Play();
    //    Debug.Log(_videoPlayer.ur);
    //    Debug.Log(T);
    //}
    private RawImage rawImage;

    private VideoPlayer videoPlayer;

    // Use this for initialization

    void Start()
    {

        rawImage = this.GetComponent<RawImage>();

        videoPlayer = this.GetComponent<VideoPlayer>();

    }

    // Update is called once per frame

    void Update()
    {
        rawImage.texture = videoPlayer.texture;
    }
}
