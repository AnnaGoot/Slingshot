using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private float maxDistance = 3f;

    private Vector2 startPoint;

    public UnityEvent<Vector2> onRelese;

    private Camera camera;

    void Start()
    {
        startPoint = transform.position;
        camera = Camera.main;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.z = 0;

        if (Vector2.Distance(startPoint, mousePosition) < maxDistance)
        {
            transform.position = mousePosition;
        }
        else
        {
            var direction = (mousePosition - startPoint).normalized * maxDistance;
            transform.position = startPoint + direction;

        }
    }

    private void OnMouseUp()
    {
        Vector2 releasePosition = transform.position;
        transform.position = startPoint;

        Vector2 delta = releasePosition - startPoint;

        onRelese?.Invoke(delta.normalized * (delta.magnitude / maxDistance));
    }

}
