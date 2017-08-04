using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask targetMask;

    [SerializeField]
    string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;

    void Start()
    {
        if(cam == null)
        {
            Debug.Log("PlayerShoot: missing camera");
            this.enabled = false;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    [Client]
    private void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, targetMask)) {
            Debug.Log("We Shot " + _hit.collider.name);
            if(_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShot (string _playerID)
    {
        Debug.Log(_playerID + " has been shot.");

        Player _player = GameManager.GetPlayer(_playerID);
        _player.RpcTakeDamage(weapon.damage);
    }
}
