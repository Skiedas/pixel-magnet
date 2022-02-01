using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetActivator : MonoBehaviour
{
    [SerializeField] private Magnet _magnet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _magnet.enabled = !_magnet.enabled;
        }
    }
}
