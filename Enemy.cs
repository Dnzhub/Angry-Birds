using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _CloudParticles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MadBird bird = collision.collider.GetComponent<MadBird>();
        if (bird != null)
        {
            Instantiate(_CloudParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        Enemy enemy = collision.collider.GetComponent<Enemy>(); // D�smanlar birbirine carpar ise bir i�lem yapma
        if (enemy != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5) // Eger d�smana yukar�dan bir�ey gelip carpar ise (y ekseni) d�sman� kaybet
        {
            Instantiate(_CloudParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
