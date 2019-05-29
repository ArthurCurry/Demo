using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoToCollection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isSelected = false;

    private AudioPlay ap;
    // Use this for initialization
    void Start()
    {
        ap = new AudioPlay();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position);
                DontDestroyOnLoad(GameObject.Find("One shot audio"));
                SceneManager.LoadScene("Collection");
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
