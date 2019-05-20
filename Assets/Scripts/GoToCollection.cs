using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoToCollection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isSelected = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
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
