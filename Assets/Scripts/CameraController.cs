

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private Transform cameraTransform;
    private float speed = 30.0f;

    //should fix in future
    private string PLAYER_NAME = "player";
    [SerializeField] private float shift_x = 10f;
    [SerializeField] private float shift_y = 6f;

    private Vector3 _origin;
    private Vector3 _difference;

    private float distance;

    private Camera _mainCamera;

    private bool _isDragging;

    private bool Check_Pause;

    public GameObject Script;

    private void Awake() {
        _mainCamera = Camera.main;

    }

    public void OnDrag(InputAction.CallbackContext ctx) {
        if (Check_Pause == false) {
            if (ctx.started) _origin = GetMousePosition;
            _isDragging = ctx.started || ctx.performed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu pause = Script.GetComponent<PauseMenu>();
        Check_Pause = pause.camera_pause;
        if (Check_Pause == false) {

            playerTransform = GameObject.Find(PLAYER_NAME).transform; 

            float x2 = playerTransform.position.x + shift_x;
            float y2 = playerTransform.position.y + shift_y;
            float step = speed * Time.deltaTime;
            Vector3 temp = new Vector3(playerTransform.position.x + shift_x, playerTransform.position.y + shift_y, transform.position.z);
            
            if (!_isDragging) { 
                transform.position = Vector3.MoveTowards(transform.position, temp, step);  
            } else {
                distance = Vector3.Distance(transform.position, playerTransform.position);
                if (Mathf.Abs(x2 - transform.position.x) <= 15 && Mathf.Abs(y2 - transform.position.y) <= 15) {
                    _difference = GetMousePosition - transform.position;
                    transform.position = _origin - _difference;
                } 
            }
        }





    }

    private Vector3 GetMousePosition => _mainCamera.ScreenToWorldPoint((Vector3)Mouse.current.position.ReadValue());
}

