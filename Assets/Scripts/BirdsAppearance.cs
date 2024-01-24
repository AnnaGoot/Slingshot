using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class BirdsAppearance
{
    [SerializeField] private float animationDuration = 1f;
    [SerializeField] private float animationForce = 2f;

    public IEnumerator AppearanceBird(AngryBird bird, Vector2 target)
    {
        yield return bird.transform.DOJump(target, animationForce, 1, animationDuration).WaitForCompletion();

    }


}