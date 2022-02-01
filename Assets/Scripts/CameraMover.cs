using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private Transform _endPosition;

    private void OnEnable()
    {
        _levelInfo.Progress.ImageComplete += OnLevelComplete;
    }

    private void OnDisable()
    {
        _levelInfo.Progress.ImageComplete -= OnLevelComplete;
    }

    private void OnLevelComplete()
    {
        transform.DORotate(_endPosition.rotation.eulerAngles, 2f);
        transform.DOMove(_endPosition.position, 2f);
    }
}
