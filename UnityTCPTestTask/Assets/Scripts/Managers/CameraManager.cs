using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public void CaptureAllObjectsInAVolume( Vector3 minBounds, Vector3 maxBounds )
    {
        float Dx = maxBounds.x - minBounds.x;
        float Dy = maxBounds.y - minBounds.y;
        float Dz = maxBounds.z - minBounds.z;
        
        Vector3 newFocusPoint = new Vector3(
            minBounds.x + Dx / 2,
            minBounds.y + Dy / 2,
            minBounds.z - (Dx > Dy ? Dx : Dy) / 2);
        Debug.Log( $"New focus: {newFocusPoint}" );
        
        _camera.transform.DOMove( newFocusPoint, 2 ).SetEase( Ease.InOutQuad );
    }
}