using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Kyle Knotek

public class ButtonControl : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] public float jumpForce = 500.0f;
    //public GameObject _xrOrigin;
    public AudioSource audioData;

    public Rigidbody _body;

    private bool IsGrounded => Physics.Raycast(
        new Vector2(transform.position.x, transform.position.y + 0.8f), Vector3.down, 0.8f);
    

    void Start()
    {
        //_body = GetComponent<Rigidbody>();
        //_collider = GetComponent<CapsuleCollider>();
        jumpActionReference.action.performed += OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        //var center = _xrOrigin.cameraInRigSpacePos;
        //_collider.center = new Vector3(center.x, _collider.center.y, center.z);
        //_collider.height = _xrOrigin.position.y;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!IsGrounded) return;
        _body.AddForce(Vector3.up * jumpForce);

        audioData.Play(0);
    }
}

