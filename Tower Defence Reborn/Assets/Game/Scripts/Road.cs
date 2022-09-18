using System;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    public Vector3 GetPosition(float progress)
    {
        if (progress < 0f || progress > 1f)
            throw new ArgumentOutOfRangeException(nameof(progress));

        return (_endPoint.position - _startPoint.position) * progress;
    }
}
