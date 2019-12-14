using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoBehaviour
{
    [SerializeField] private Vector3 _playZone;
    [SerializeField] private Vector3 _playZonePosition;
    [SerializeField] private Color _zoneColor = Color.blue;
    private Rect _rect;

    public bool IsOutOfBounds(Vector3 position)
    {
        Vector3 rectPosition = _playZonePosition - (_playZone / 2);
        _rect = new Rect(rectPosition, _playZone);
        return _rect.Contains(position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _zoneColor;
        Gizmos.DrawCube(_playZonePosition, _playZone);
    }
}
