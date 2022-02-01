using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private int _toatlCubes;
    [SerializeField] private LevelProgress _progress;

    [SerializeField] private RaycastBlockPanel _panel;
    [SerializeField] private Rail _rail;
    [SerializeField] private GameObject _picture;
    [SerializeField] private ParticleSystem _confeti;
    [SerializeField] private TMP_Text _breakText;

    public int TotalCubes => _toatlCubes;
    public LevelProgress Progress => _progress;
    public RaycastBlockPanel RaycastBlockPanel => _panel;
    public Rail Rail => _rail;
    public GameObject Picture => _picture;
    public ParticleSystem Confeti => _confeti;
    public TMP_Text BreakText => _breakText;
}
