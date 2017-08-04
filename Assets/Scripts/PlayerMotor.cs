using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 playerVelocity = Vector3.zero;
    private Vector3 playerRotation = Vector3.zero;
    private Vector3 playerThrust = Vector3.zero;
    private float cameraRotation = 0f;
    private float deltaRotation = 0f;

    private Rigidbody rb;

    [SerializeField]
    private ForceMode thrusterForceMode = ForceMode.Force;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float cameraRotationMax = 90f;

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

    internal void RotateCamera(float _deltaRotation)
    {
        deltaRotation = _deltaRotation;
    }

    internal void ThrustPlayer(Vector3 _playerThrust)
    {
        playerThrust = _playerThrust;
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

        if(playerThrust != Vector3.zero)
        {
            rb.AddForce(playerThrust, thrusterForceMode);
        }
    }

    void PerformRotation()
    {
        if (Cursor.lockState == CursorLockMode.None) return;//camera only turns when mouse locked

        rb.MoveRotation(rb.rotation * Quaternion.Euler(playerRotation));
        if(cam != null)
        {
            cameraRotation += deltaRotation;
            cameraRotation = Mathf.Clamp(cameraRotation, -cameraRotationMax, cameraRotationMax);
            cam.transform.localEulerAngles = new Vector3(cameraRotation, 0f, 0f);
        }
    }
}
