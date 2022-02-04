using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private Cube _smallCubeTemplate;
    [SerializeField] private CustomSizeCube _bigCubeTemplate;
    [SerializeField] private SpawnArea _spawnArea;
    [SerializeField] private float _spawnDelay;

    private int _smallCubesCount;
    private int _bigCubesCount;
    private List<Cube> _spawnedCubes = new List<Cube>();

    private void Start()
    {
        CalculateCubesCount();

        StartCoroutine(SpawnAllCubes());
    }

    private void CalculateCubesCount()
    {
        _smallCubesCount = _levelInfo.TotalCubes % _bigCubeTemplate.CubesCount;
        _bigCubesCount = _levelInfo.TotalCubes / _bigCubeTemplate.CubesCount;
    }

    private void SpawnCube(Cube cubeTemplate)
    {
        var cube = Instantiate(cubeTemplate, _spawnArea.GetRandomPosition(), Quaternion.identity);
        cube.Completed += OnCubeCompleted;
        cube.Destroyed += OnCubeDestroyed;
        _spawnedCubes.Add(cube);
    }

    private IEnumerator SpawnAllCubes()
    {
        for (int i = 0; i < _bigCubesCount; i++)
        {
            var bigCube = Instantiate(_bigCubeTemplate, _spawnArea.GetRandomPosition(), Quaternion.identity);

            for (int j = 0; j < bigCube.CubesCount; j++)
            {
                SpawnCube(bigCube.GetCube(j));
            }

            yield return new WaitForSeconds(_spawnDelay);
        }

        for (int i = 0; i < _smallCubesCount; i++)
        {
            SpawnCube(_smallCubeTemplate);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void OnCubeCompleted(Cube cube)
    {
        cube.Completed -= OnCubeCompleted;
        _levelInfo.Progress.CompleteCube();
    }

    private void OnCubeDestroyed(Cube cube)
    {
        cube.Destroyed -= OnCubeDestroyed;
        _levelInfo.Progress.ChangeDestroyedCubesCount();
    }
}
