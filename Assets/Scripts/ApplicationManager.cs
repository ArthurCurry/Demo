using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

    public GameObject gameManager;
    private void Start()
    {
        GameObject.DontDestroyOnLoad(gameManager.gameObject);
    }
    public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

    public void PlayGame()
    {
        SceneManager.LoadScene("Selection");
    }
}
