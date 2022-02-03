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

    public void MoveRail(float vertical)
    {
        transform.position += vertical * Vector3.forward * _speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, _minZPosition, _maxZPosition));
    }

    public void MoveMagnet(float horizontal)
    {
        _magnet.position += horizontal * Vector3.right * _speed * Time.deltaTime;
        _magnet.position = new Vector3(Mathf.Clamp(_magnet.position.x, _minXPosition, _maxXPosition), _magnet.position.y, _magnet.position.z);
    }
}
