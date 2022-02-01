using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailTransperency : MonoBehaviour
{
    [SerializeField] private float _minZPosition;
    [SerializeField] private float _maxZPosition;
    [SerializeField] private Material _material;

    private void Update()
    {
        ChangeAlpha();
    }

    private void ChangeAlpha()
    {
        Color currentColor = _material.color;

        currentColor.a = (transform.position.z + Mathf.Abs(_minZPosition)) / (_maxZPosition + Mathf.Abs(_minZPosition));

        _material.color = currentColor;
    }
}
