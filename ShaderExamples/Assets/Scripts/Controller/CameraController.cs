using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private float _rotationSpeed = 3.0f;

    private Vector3 _rotation = Vector3.zero;   
    private Vector3 _moveVector = Vector3.zero;

    private Rigidbody _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _rigid.useGravity = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _rotation += new Vector3(-Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"));
        transform.eulerAngles = _rotation * _rotationSpeed;

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        _moveVector=new Vector3(x,0, z)* _moveSpeed;
    }

    private void FixedUpdate()
    {
        _rigid.velocity = transform.TransformDirection(_moveVector);
    }
}
