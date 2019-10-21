/*===============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/

using UnityEngine.Video;

public class VideoTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PROTECTED_METHODS
    protected override void OnTrackingFound()
    {
        GetComponentInChildren<VideoPlayer>().Play();
        base.OnTrackingFound();
    }
    protected override void OnTrackingLost()
    {
        //mTrackableBehaviour.GetComponentInChildren<VideoController>().Pause();
        GetComponentInChildren<VideoPlayer>().Stop();
        base.OnTrackingLost();
    }

    #endregion // PROTECTED_METHODS
}
