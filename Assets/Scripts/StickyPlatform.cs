using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Set Parent se nam trong cai gameobject la Moving Flatform => khi Mongving di chuyen, nhan vat se di chuyen theo
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Khi nhan vat nhay ra ngoai se quay ve nhu cu 
            collision.gameObject.transform.SetParent(null);
        }
    }
}
