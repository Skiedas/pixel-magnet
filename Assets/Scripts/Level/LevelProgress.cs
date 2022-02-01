using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;

    private int _completedCubes;
    private int _destroyedCubes;

    public int CompletedCubes => _completedCubes;
    public int DestroyedCubes => _destroyedCubes;

    public event UnityAction CompletedCubesCountChanged;
    public event UnityAction ImageComplete;

    public void CompleteCube()
    {
        _completedCubes++;
        CompletedCubesCountChanged?.Invoke();

        if(_completedCubes == _levelInfo.TotalCubes)
        {
            ImageComplete?.Invoke();
            _levelInfo.RaycastBlockPanel.gameObject.SetActive(false);
            _levelInfo.Rail.gameObject.SetActive(false);
            _levelInfo.Picture.SetActive(true);
            _levelInfo.BreakText.gameObject.SetActive(true);
        }
    }

    public void ChangeDestroyedCubesCount()
    {
        _destroyedCubes++;

        if(_destroyedCubes == _levelInfo.TotalCubes)
        {
            _levelInfo.Confeti.Play();
        }
    }
}
