using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField] private int hp;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Construction"))
        {
            hp--;

            if (hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }





}
