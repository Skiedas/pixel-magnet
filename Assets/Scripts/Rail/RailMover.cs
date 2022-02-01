using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _magnet;

    [SerializeField] private float _minZPosition;
    [SerializeField] private float _maxZPosition;
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxXPosition;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && _magnet.position.x > _minXPosition)
        {
            Move(_magnet, Vector3.left);
        }

        if (Input.GetKey(KeyCode.D) && _magnet.position.x < _maxXPosition)
        {
            Move(_magnet, Vector3.right);
        }

        if (Input.GetKey(KeyCode.W) && transform.position.z < _maxZPosition)
        {
            Move(transform, Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.z > _minZPosition)
        {
            Move(transform, Vector3.back);
        }
    }

    private void Move(Transform movedItem, Vector3 direction)
    {
        movedItem.position += direction * _speed * Time.deltaTime;
    }
}
