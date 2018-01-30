using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnShoeDetection : MonoBehaviour, ITrackableEventHandler
{
        private TrackableBehaviour mTrackableBehaviour;

    [SerializeField]
    GameObject scanningObject;

    [SerializeField]
    GameObject detectedObject;

    [SerializeField]
    GameObject holoShoe;

    [SerializeField]
    GameObject experienceContainer;

    [SerializeField]
    AudioSource detectedAudioSource;

    [SerializeField]
    GameObject shoeContainer;

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
                scanningObject.SetActive(false);
                transform.parent = null;
                shoeContainer.SetActive(false);
                StartCoroutine(Detected());
            }
          }
 
        }


    IEnumerator Detected()
    {
        detectedObject.SetActive(true);
        yield return new WaitForSeconds(2);
        detectedObject.SetActive(false);
        StartCoroutine(FlickeringShoe());

    }

    IEnumerator FlickeringShoe()
    {
        holoShoe.SetActive(true);
        detectedAudioSource.Play();
        yield return new WaitForSeconds(3);
        holoShoe.SetActive(false);
        detectedAudioSource.Stop();
        experienceContainer.SetActive(true);

    }
    }
