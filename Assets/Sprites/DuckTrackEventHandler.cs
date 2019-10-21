using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTrackEventHandler : DefaultTrackableEventHandler
{
    [SerializeField]
    private Material material;
    [SerializeField]
    private Texture texture;

    protected override void OnTrackingLost()
    {
        if (mTrackableBehaviour.TrackableName == "yazi")
        {
            material.mainTexture = texture;
        }
        base.OnTrackingLost();
    }
}
