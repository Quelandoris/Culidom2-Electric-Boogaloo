using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    //end-turn button
    public GameObject endTurnButton;

    //mask to indicate if we can move
    //public GameObject cannotMoveMask;

    // how fast camera moves
    public float cameraMoveSpeed = 12.0f;
    public float cameraDragMoveSpeed = 0.75f;
    public float edgePanSpeed = 6.0f;
    public float zoomSpeed = 0.1f;
    public Vector3 startPos = new Vector3(-5, 8, -5);

    // bounds on movement
    public float MIN_X;
    public float MAX_X;
    public float MIN_Z;
    public float MAX_Z;
    public float maxZoomOut;
    public float minZoomIn;

    public bool canMove = true;
    public bool overArea = false;
    public bool tutorialOn = true;
    bool moveMinX = false, moveMaxX = false, moveMinY= false, moveMaxY = false, moveMinZ = false, moveMaxZ = false; // might use to stop camera from moving up when reaching
                                                                                                                    // the end

    public Camera mainCamera;

    private void Start()
    {
        transform.position = startPos;                                          // starting position of the camera
    }

    public void TurnCanMoveTrue() {
        canMove = true;
        //cannotMoveMask.SetActive(false);
    }

    public void TurnCanMoveFalse() {
        canMove = false;
        //cannotMoveMask.SetActive(true);
    }

    public void TurnOnEndTurn() {
        endTurnButton.SetActive(true);
    }

    public void TurnOffEndTurn() {
        endTurnButton.SetActive(false);
    }
    public void OverArea() {
        if ((Input.mousePosition.y >= Screen.height * 0.95 && Input.mousePosition.x <= Screen.width * 0.34) ||
            (Input.mousePosition.y <= Screen.height * 0.15 && Input.mousePosition.x >= Screen.width * 0.81) || 
           /* over tutorial*/ (Input.mousePosition.y <= Screen.height * 0.25 && Input.mousePosition.x >= Screen.width * 0.90 && tutorialOn) ||
            /* over tutorial*/(Input.mousePosition.y <= Screen.height * 0.47 && Input.mousePosition.x >= Screen.width * 0.95 & tutorialOn))
        {
            overArea = true;
        }
        else {
           overArea = false;
        }
    }

    void Update () {
        // moving right and left
        bool dragging = false;
        OverArea();
        if (canMove)
        {
            //RMB drag movement
            if (Input.GetMouseButton(1)) {
                dragging = true;
                transform.Translate(-Input.GetAxis("Mouse X")*cameraDragMoveSpeed, 0, -Input.GetAxis("Mouse Y") * cameraDragMoveSpeed);
            }

            // Right and Left
            if (Input.GetKey(KeyCode.A))
            {
            
                transform.Translate(Vector3.right * Time.deltaTime * -cameraMoveSpeed);
                
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
            }

            // moving forward and back
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -cameraMoveSpeed);
            }

            // using mouse to move
            if (!dragging)
            {
                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) //If not mousing over a UI element
                {
                    if (Input.mousePosition.x >= Screen.width * 0.95)
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * edgePanSpeed);
                    }
                    if (Input.mousePosition.x <= Screen.width * 0.05)
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * -edgePanSpeed);
                    }
                    if (Input.mousePosition.y >= Screen.height * 0.99)
                    {
                        transform.Translate(Vector3.forward * Time.deltaTime * edgePanSpeed);
                    }
                    if (Input.mousePosition.y <= Screen.height * 0.05)
                    {
                        transform.Translate(Vector3.forward * Time.deltaTime * -edgePanSpeed);
                    }
                }
                
            }

            // Restricting Movement
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MIN_X, MAX_X), transform.position.y, Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));

            // zooming
            float zoom = (Input.GetAxis("Mouse ScrollWheel"));




            if (zoom > 0)
            {
                if (mainCamera.orthographicSize > minZoomIn)
                {
                    mainCamera.orthographicSize -= zoomSpeed;
                }
            }
            else if (zoom < 0)
            {
                if (mainCamera.orthographicSize < maxZoomOut)
                {
                    mainCamera.orthographicSize += zoomSpeed;
                }
            }

            if (Input.GetKey(KeyCode.PageUp))
            {
                if (mainCamera.orthographicSize < maxZoomOut)
                {
                    mainCamera.orthographicSize += zoomSpeed;
                }
            }
            else if (Input.GetKey(KeyCode.PageDown))
            {
                if (mainCamera.orthographicSize > minZoomIn)
                {
                    mainCamera.orthographicSize -= zoomSpeed;
                }
            }

            // Return to regular room
            if (Input.GetKeyDown(KeyCode.Z))
            {
                mainCamera.orthographicSize = 10;
            }
        }

    }
}
