using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject _player;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    { 

    }

    private void LateUpdate()
    {
        transform.rotation = _player.transform.rotation;
        if (this.CompareTag("3rdPerson"))
        {
            transform.LookAt(_player.transform.position);
        }
    }
}
