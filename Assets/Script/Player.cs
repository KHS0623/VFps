using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject[] Gun;

    Rigidbody ri;

    [Header("스텟")]
    public float Speed = 0;
    public float Hp = 0;
    public float MaxHp = 100;


    //마우스
    public float TurnSpeed = 4f;

    private float xRotate = 0;
    private float yRotate = 0;


    private void Awake()
    {
        ri = GetComponent<Rigidbody>();
    }

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        Move();
        CameraMove();
        MouseMove();
        if (Input.GetKeyDown(KeyCode.K))
            MouseLock();
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        transform.Translate(x * Speed * Time.deltaTime, 0 , z * Speed * Time.deltaTime);
        Quaternion _rotate = Camera.transform.rotation;
        _rotate.x = 0;
        _rotate.z = 0;
        transform.rotation = _rotate;
        
    }

    void CameraMove()
    {
        Camera.transform.position = new Vector3(transform.position.x, transform.position.y  + 0.6f, transform.position.z);
    }

    void MouseMove()
    {
        float _yRotateSize = Input.GetAxis("Mouse X") * TurnSpeed;

        yRotate = Camera.transform.eulerAngles.y + _yRotateSize;

        float _xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;

        
        xRotate = Mathf.Clamp(xRotate + _xRotateSize, -45, 80);

        Camera.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    } 

    void MouseLock()
    {
        if(UnityEngine.Cursor.visible == true)
        {
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UnityEngine.Cursor.visible = transform;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    }




}
