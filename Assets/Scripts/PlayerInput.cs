using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";

    [SerializeField] private Rail _rail;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                var hits = Physics.SphereCastAll(ray, .15f, 100, LayerMask.GetMask("Cube"));

                foreach (var hit in hits)
                {
                    if (hit.collider.TryGetComponent(out Cube cube))
                    {
                        Destroy(cube.gameObject);
                    }
                }
            }
        }

        if(Input.GetAxis(Vertical) != 0)
        {
            _rail.Mover.MoveRail(Input.GetAxis(Vertical));
        }

        if (Input.GetAxis(Horizontal) != 0)
        {
            _rail.Mover.MoveMagnet(Input.GetAxis(Horizontal));
        }
    }
}
