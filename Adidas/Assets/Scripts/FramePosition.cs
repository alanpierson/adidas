using UnityEngine;

public class FramePosition : MonoBehaviour {

    [SerializeField]
    int m_AnimationFrames;

    [SerializeField]
    int m_MaxPosition;

    private static int mDivisor;

    public static int mFramePosition;

	void Start () {
        mDivisor = m_MaxPosition / m_AnimationFrames;
	}
	
	void Update () {
        mFramePosition = -((int)GetComponent<RectTransform>().offsetMin.x / mDivisor);
        //Debug.Log(mFramePosition);
	}
}
