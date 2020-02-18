using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    float damage = 25f;
    private void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime);
        if (gameObject.transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyRock()
    {
        Destroy(gameObject);
    }
}
