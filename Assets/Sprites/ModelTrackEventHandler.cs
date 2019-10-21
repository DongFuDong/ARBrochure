using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTrackEventHandler : DefaultTrackableEventHandler
{
    [SerializeField]
    private GameObject _child;
    private Vector3 _startPosition;
    private Quaternion _startRotion;
    protected override void Start()
    {
        _startPosition = _child.transform.position;
        _startRotion = _child.transform.rotation;
        base.Start();
    }
    protected override void OnTrackingFound()
    {
        _child.SetActive(true);
        base.OnTrackingFound();
    }
    protected override void OnTrackingLost()
    {
        _child.transform.position = _startPosition;
        _child.transform.rotation = _startRotion;
        _child.SetActive(false);
        base.OnTrackingLost();
    }
}
