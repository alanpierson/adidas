using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnShoeDetection : MonoBehaviour, ITrackableEventHandler
{
        private TrackableBehaviour mTrackableBehaviour;

    [SerializeField]
    GameObject mGameObjectScan;

    [SerializeField]
    GameObject mGameObjectDetect;

    [SerializeField]
    GameObject mGameObjectShoe;

    [SerializeField]
    GameObject mGameObjectExperience;

    private bool mFirstTime = true;

    void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED)
            {
            //When target is found
            if (mFirstTime)
            {
                mFirstTime = false;
                mGameObjectScan.SetActive(false);
                StartCoroutine(Detected());
            }
          }
 
        }


    IEnumerator Detected()
    {
        mGameObjectDetect.SetActive(true);
        yield return new WaitForSeconds(2);
        mGameObjectDetect.SetActive(false);
        StartCoroutine(FlickeringShoe());

    }

    IEnumerator FlickeringShoe()
    {
        mGameObjectShoe.SetActive(true);
        yield return new WaitForSeconds(3);
        mGameObjectShoe.SetActive(false);
        mGameObjectExperience.SetActive(true);

    }
    }
