using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private CameraMovement camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        camera.isDragging = true;
    }

    private void OnMouseUp()
    {
        camera.isDragging = false;
    }

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }
}
