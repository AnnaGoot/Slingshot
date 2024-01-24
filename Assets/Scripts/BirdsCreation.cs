using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsCreation : MonoBehaviour
{
    [SerializeField] private AngryBird Angrybird_prefab;

    public AngryBird GetAngryBird()
    {
        return Instantiate(Angrybird_prefab, transform.position, Quaternion.identity);

    }



}
