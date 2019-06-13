using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

    public GameObject gameManager;

    private AudioPlay ap;
    private void Start()
    {
        ap = new AudioPlay();
        GameObject.DontDestroyOnLoad(gameManager.gameObject);
    }
    public void Quit () 
	{
#if UNITY_EDITOR
        ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
        DontDestroyOnLoad(GameObject.Find("One shot audio"));
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

    public void PlayGame()
    {
        ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
        DontDestroyOnLoad(GameObject.Find("One shot audio"));
        SceneManager.LoadScene("Selection2");
    }

    public void PlayAudio()
    {
        ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
        DontDestroyOnLoad(GameObject.Find("One shot audio"));
    }
}
