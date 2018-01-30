using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnShoeDetection : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour trackableBehaviour;

    [SerializeField]
    GameObject scanningTextObject;

    [SerializeField]
    GameObject detectedTextObject;

    [SerializeField]
    GameObject holoShoe;

    [SerializeField]
    GameObject experienceContainer;

    [SerializeField]
    AudioSource detectedAudioSource;

    private bool firstTime = true;

    void Start()
        {
            trackableBehaviour = GetComponent<TrackableBehaviour>();
            if (trackableBehaviour)
            {
                trackableBehaviour.RegisterTrackableEventHandler(this);
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
            if (firstTime)
            {
                firstTime = false;
                scanningTextObject.SetActive(false);
                StartCoroutine(Detected());
            }
            }
        }


    IEnumerator Detected()
    {
        detectedTextObject.SetActive(true);
        yield return new WaitForSeconds(2);
        detectedTextObject.SetActive(false);
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
