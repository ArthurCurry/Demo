using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private AudioPlay ap;
    public bool isSelected = false;
    // Use this for initialization
    void Start()
    {
        ap = new AudioPlay();
	}
	
	// Update is called once per frame
	void Update () {
        if(isSelected == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
                DontDestroyOnLoad(GameObject.Find("One shot audio"));

                SceneManager.LoadScene("Menu");
            }
        }                           
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        isSelected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelected = false;
    }
}
