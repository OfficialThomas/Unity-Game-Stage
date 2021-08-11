using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float _moveSpeed = 1;
    public float _rotationSpeed = 1;
    public GameObject _bullet;
    private Rigidbody _rigidbody;
    private Camera _3rdPerson;
    private Camera _1stPerson;

    // Start is called before the first frame update
    void Start()
    {
        //https://docs.unity3d.com/ScriptReference/Cursor-lockState.html
        Cursor.lockState = CursorLockMode.Confined;

        _rigidbody = GetComponent<Rigidbody>();

        _3rdPerson = GameObject.Find("3rd Person").GetComponent<Camera>();
        _1stPerson = GameObject.Find("1st Person").GetComponent<Camera>();
        _3rdPerson.enabled = true;
        _1stPerson.enabled = false;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.forward * Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime + transform.right * Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        _rigidbody.AddForce(newPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, transform.position + transform.forward*2 + transform.up*1, transform.rotation);
        }

        if (Input.GetButton("Fire2"))
        {
            Ray ray = new Ray(transform.position + transform.up, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Wall"))
                {
                    hit.collider.gameObject.transform.localScale *= 0.99f;

                }
            }
        }

        //https://docs.unity3d.com/Manual/MultipleCameras.html
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_3rdPerson.enabled)
            {
                _3rdPerson.enabled = false;
                _1stPerson.enabled = true;
            }
            else
            {
                _1stPerson.enabled = false;
                _3rdPerson.enabled = true;
            }
        }
    }

    void LateUpdate()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime, 0));
    }

    public void ChangePOV()
    {
        if (_3rdPerson.enabled)
        {
            _3rdPerson.enabled = false;
            _1stPerson.enabled = true;
        }
        else
        {
            _1stPerson.enabled = false;
            _3rdPerson.enabled = true;
        }

    }
}
