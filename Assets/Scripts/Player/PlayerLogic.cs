using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLogic : MonoBehaviour
{
    //Data
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Transform _head;
    private float _xRotation, _yMove;
    private CharacterController _controller;

    private void Awake()
    {
        _playerData.IsMove = true;
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(!_playerData.IsMove)
            return;
        Move(transform, _controller);
        Rotate(transform, _head);
    }

    public void Move(Transform playerTransform, CharacterController controller)
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var curSpeed = _playerData.PlayerSpeed;
        if (Input.GetButton("Sprint"))
            curSpeed *= _playerData.SprintModifier;

        var moveDirection = (playerTransform.forward * move.z + playerTransform.right * move.x) * Time.deltaTime * curSpeed;
        
        if (!_controller.isGrounded)
        {
            _yMove -= _playerData.Gravity * Time.deltaTime;
        }
        else if (Input.GetButtonDown("Jump"))
        {
            _yMove = _playerData.JumpSpeed;
        }

        moveDirection.y = _yMove;
        
        if (move != Vector3.zero || _yMove != 0)
        {
            controller.Move(moveDirection);
        }
    }

    public void Rotate(Transform playerTransform, Transform  headTransform)
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * _playerData.MouseSensitivity;
        float verticalRotation = Input.GetAxis("Mouse Y") * _playerData.MouseSensitivity;

        _xRotation = Mathf.Clamp(_xRotation - verticalRotation, _playerData.HeadLimit[0], _playerData.HeadLimit[1]);
        playerTransform.Rotate(0, horizontalRotation, 0);
        headTransform.localRotation = Quaternion.Euler(_xRotation,0,0);
    }
}
