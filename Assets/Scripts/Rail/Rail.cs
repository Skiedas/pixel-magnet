using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] private RailMover _mover;

    public RailMover Mover => _mover;
}
