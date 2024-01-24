using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private BirdsAppearance birdsAppearance;
    [SerializeField] private float slingPower = 25f;
    [SerializeField] private int count = 5;
    [SerializeField] private ShootPoint shootPoint;
    [SerializeField] private BirdsCreation creation;

    private IEnumerator Start()
    {
        for (int i = 0; i < count; i++)
        {
            var bird = creation.GetAngryBird();
            yield return SeatAngryBird(bird);
            yield return WaitForShoot(bird);
        }
    }

    private IEnumerator WaitForShoot(AngryBird bird)
    {
        var isDone = false;

        void Shoot(Vector2 direction)
        {
            isDone = true;
            bird.Launch(direction * -slingPower);
        }

        shootPoint.onRelese.AddListener(Shoot);

        while (!isDone)
        {
            bird.transform.position = shootPoint.transform.position;
            yield return null;
        }

        shootPoint.onRelese.RemoveAllListeners();
    }

    private IEnumerator SeatAngryBird(AngryBird bird)
    {
        shootPoint.enabled = false;
        yield return birdsAppearance.AppearanceBird(bird, shootPoint.transform.position);
        shootPoint.enabled = true;
        //throw new NotImplementedException();

    }



}
