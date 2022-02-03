using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(InteractableItem))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _sparkles;

    private Rigidbody _rigidBody;
    private Collider _collider;
    private InteractableItem _interactable;

    private GridCell _cell;

    public event UnityAction<Cube> Completed;
    public event UnityAction<Cube> Destroyed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _interactable = GetComponent<InteractableItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_cell == null)
        {
            if (other.TryGetComponent(out GridCell cell))
            {
                _cell = cell;
                StartCoroutine(PlaceCube(cell.gameObject));

                _rigidBody.isKinematic = true;
                _collider.isTrigger = true;
                _interactable.enabled = false;

                other.enabled = false;
            }
        }
    }

    private void OnDestroy()
    {
        Instantiate(_sparkles, transform.position, Quaternion.identity);
        Destroyed?.Invoke(this);
    }

    private IEnumerator PlaceCube(GameObject cell)
    {
        yield return new WaitForSeconds(Random.Range(.05f, .1f));

        Sequence cubeMoving = DOTween.Sequence();
        cubeMoving.Append(transform.DORotate(Vector3.zero, 1f)).Join(transform.DOMove(cell.transform.position + new Vector3(0, 0.1f, 0), 1f))
                    .Append(transform.DOPunchPosition(Vector3.down / 7, .3f, 2)).Append(transform.DOMove(cell.transform.position, 0.3f));

        Completed?.Invoke(this);

    }
}
