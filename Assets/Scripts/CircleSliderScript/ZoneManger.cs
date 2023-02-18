using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZoneManger : MonoBehaviour
{
    public int TargetNumber;
    
    public void ObjectMove(Transform[] targetObject) =>
        transform.DOMove(
            new Vector2(targetObject[TargetNumber].transform.position.x,
                targetObject[TargetNumber].transform.position.y),
            0.4f).SetEase(Ease.Flash);
    
}