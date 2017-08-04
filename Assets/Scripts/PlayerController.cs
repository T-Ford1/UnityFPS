using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float playerSpeed = 5f;
    [SerializeField]
    private float playerLook = 5f;
    [SerializeField]
    private float playerThrust = 100f;

    private PlayerMotor motor;

	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        //calculate movement as a 3D vector

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * playerSpeed;

        motor.MovePlayer(_velocity);


        bool _jump = Input.GetButton("Jump");

        Vector3 _playerThrust = Vector3.zero;

        if (_jump)
        {
            _playerThrust = Vector3.up * playerThrust;
        }
        motor.ThrustPlayer(_playerThrust);

        //calculate rotation as a 3D vector

        float _yRot = Input.GetAxisRaw("Mouse X");//move mouse on x, rotate around the y axis

        Vector3 _playerRotation = new Vector3(0f, _yRot, 0f) * playerLook;

        //Apply rotation
        motor.RotatePlayer(_playerRotation);


        float _xRot = -Input.GetAxisRaw("Mouse Y");

        float _deltaRotation = _xRot * playerLook;

        //Apply rotation
        motor.RotateCamera(_deltaRotation);

    }
}
