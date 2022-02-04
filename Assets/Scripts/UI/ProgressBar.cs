using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private Slider _slider;
    [SerializeField] private Sprite _completedStage;
    [SerializeField] private Image _nextStageImage;

    private void OnEnable()
    {
        _levelInfo.Progress.CompletedCubesCountChanged += OnCompletedCubesCountChanged;
    }

    private void OnDisable()
    {
        _levelInfo.Progress.CompletedCubesCountChanged -= OnCompletedCubesCountChanged;
    }

    private void OnCompletedCubesCountChanged()
    {
        ChangeSliderValue();

        if(_slider.value == 1)
        {
            _nextStageImage.sprite = _completedStage;
        }
    }

    private void ChangeSliderValue()
    {
        _slider.value = (float)_levelInfo.Progress.CompletedCubes / (_levelInfo.TotalCubes);
    }
}
