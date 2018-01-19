using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    [SerializeField]
    private int m_SceneIndex;

	public void LoadFirstScene()
    {
        SceneManager.LoadScene(m_SceneIndex);
    }
}
