using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperMovement : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float Speed;

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        Vector3 v = startingPosition;
        v.z += distanceToCover*Mathf.Sin(Time.time*Speed);
        transform.position = v;
    }
}
