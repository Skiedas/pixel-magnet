using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSizeCube : MonoBehaviour
{
    [SerializeField] private Cube[] _cubes;

    public int CubesCount => _cubes.Length;

    public Cube GetCube(int number)
    {
        return _cubes[number];
    }
}