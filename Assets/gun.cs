using UnityEngine;
using System.Collections;
public class gun : MonoBehaviour
{
    [SerializeField]
    private Transform guntip;

    [SerializeField]
    private GameObject ammo;
    private Vector2 lookDirection;
    private float lookangle;

    void Start()
    {

    }
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookangle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookangle - 0f);
        if (Input.GetMouseButtonDown(0))
        {
            firebullet();
        }
    }
    private void firebullet()
    {
        GameObject firebullet = Instantiate(ammo, guntip.position, guntip.rotation);
        firebullet.GetComponent<Rigidbody2D>().velocity=guntip.right * 10f;
    }
}
