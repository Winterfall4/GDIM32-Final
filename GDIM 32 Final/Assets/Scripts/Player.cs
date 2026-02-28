using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private GameObject _ui;
    public GameObject cursorui;
    private Transform _cameraTrans;
    private float _rotationX;
    private float _rotationY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cameraTrans = Camera.main.transform;
        cursorui.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        _rotationY += mouseY * _mouseSensitivity;
        _rotationY = Mathf.Clamp(_rotationY, -60.0f, 60.0f);

        float mouseX = Input.GetAxis("Mouse X");
        _rotationX += mouseX * _mouseSensitivity;

        _cameraTrans.localEulerAngles = new Vector3(-_rotationY, 0, 0);
        transform.localEulerAngles = new Vector3(0, _rotationX, 0);

        if (_ui.activeSelf == false)
        {
            float vertical = Input.GetAxis("Vertical");
            Vector3 move = (transform.forward * vertical) * _moveSpeed;
            _playerRigidbody.velocity = new Vector3(move.x, _playerRigidbody.velocity.y, move.z);
        }
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_ui.activeSelf == false)
            {
                _animator.SetBool("Walk", true);
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
           
            _animator.SetBool("Walk", false);
        }
    }
}
