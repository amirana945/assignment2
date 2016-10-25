using UnityEngine;
using System.Collections;

public class BoxDestroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathPlat"))
        {
            Destroy(this.gameObject);
        }
    }
}