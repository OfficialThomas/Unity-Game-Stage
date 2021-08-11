using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject _positionOne;
    public GameObject _positionTwo;
    public float _speed = 1;
    public float _maxDifference = 0.1f;
    private bool _forward = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _positionOne.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_forward)
        {
            transform.LookAt(_positionTwo.transform);

            Vector3 current = transform.position;
            Vector3 final = _positionTwo.transform.position;
            transform.position = Vector3.Lerp(current, final, _speed * Time.deltaTime);

            if (Mathf.Abs(current.x - final.x) <= _maxDifference && Mathf.Abs(current.y - final.y) <= _maxDifference && Mathf.Abs(current.z - final.z) <= _maxDifference)
            {
                _forward = false;
            }
        }
        else
        {
            transform.LookAt(_positionOne.transform);

            Vector3 current = transform.position;
            Vector3 final = _positionOne.transform.position;
            transform.position = Vector3.Lerp(current, final, _speed * Time.deltaTime);

            if (Mathf.Abs(current.x - final.x) <= _maxDifference && Mathf.Abs(current.y - final.y) <= _maxDifference && Mathf.Abs(current.z - final.z) <= _maxDifference)
            {
                _forward = true;
            }
        }
        
    }
}
