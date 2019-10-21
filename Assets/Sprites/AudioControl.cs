using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private GameObject audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Audio");
        DontDestroyOnLoad(audio);
    }
}
