using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 playerVelocity = Vector3.zero;
    private Vector3 playerRotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    [SerializeField]
    private Camera cam;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    internal void MovePlayer(Vector3 _playerVelocity)
    {
        playerVelocity = _playerVelocity;
    }

    internal void RotatePlayer(Vector3 _playerRotation)
    {
        playerRotation = _playerRotation;
    }

    internal void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate () {
        PerformMovement();
        PerformRotation();
	}

    
    void PerformMovement()
    {
        if(playerVelocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + playerVelocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(playerRotation));
        if(cam != null)
        {
            cam.transform.Rotate(cameraRotation);
        }
    }
}
