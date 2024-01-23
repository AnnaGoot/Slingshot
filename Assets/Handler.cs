using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Handler : MonoBehaviour
{

    private bool isDragging;

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("Fly");
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(newPosition);
        }
    
    }

}
