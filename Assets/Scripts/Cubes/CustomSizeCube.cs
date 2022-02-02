using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSizeCube : MonoBehaviour
{
    [SerializeField] private Cube[] _cubes;

    private int _cubeSize;

    public int TotalCubes => _cubes.Length;
    public int CubeSize => _cubeSize;


    private void Awake()
    {
        _cubeSize = (int)Mathf.Sqrt(TotalCubes);
    }

    public Cube GetCube(int number)
    {
        return _cubes[number];
    }
}