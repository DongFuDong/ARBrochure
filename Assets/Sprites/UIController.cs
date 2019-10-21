using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _tip;
    private bool _isTipActive = false;

    public void Return()
    {
        Application.LoadLevel("AR");
    }
    public void Help()
    {
        if (_isTipActive)
        {
            _tip.SetActive(false);
        }
        else
        {
            _tip.SetActive(true);
        }
    }
}
