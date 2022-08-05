using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Менеджер поведения мыши
/// </summary>
public class MouseManager : MonoBehaviour
{
    [SerializeField] Camera cameraMain;
    [SerializeField] GameObject plane;
    [SerializeField] SpawnManager spawnManager;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == plane)
                    spawnManager.SpawnAtPoint(hit.point);
            }
        }
    }
}
