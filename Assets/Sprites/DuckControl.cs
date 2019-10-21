using UnityEngine;
using System.Collections;

public class DuckControl : MonoBehaviour
{
    private Animation animation;
    private AudioClip audioClip;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Material material;
    [SerializeField]
    private Texture texture;

    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animation>();
        audioClip = audioSource.clip;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//鼠标左键点下
        {
            //住摄像机向鼠标位置发射射线  
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mHit;
            //射线检验  
            if (Physics.Raycast(mRay, out mHit))
            {
                if (mHit.collider.gameObject.tag == "duck")
                {
                    PlayAudio("Audio/duck_attack");
                    if (!animation.IsPlaying("attack"))
                    {
                        animation.Play("idle");
                    }
                    material.mainTexture = texture;
                }
            }
        }
        if (Input.touchCount == 1)
        {
            //住摄像机向鼠标位置发射射线  
            Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit mHit;
            //射线检验  
            if (Physics.Raycast(mRay, out mHit))
            {
                if (mHit.collider.gameObject.tag == "duck")
                {
                    PlayAudio("Audio/duck_attack");
                    if (!animation.IsPlaying("attack"))
                    {
                        animation.Play("idle");
                    }
                    material.mainTexture = texture;
                }
            }
        }
    }

    void PlayAudio(string s)
    {
        audioClip = Resources.Load(s) as AudioClip;
        audioSource.clip = audioClip;
        audioSource.Play();
        animation.Play("attack");
    }
}
