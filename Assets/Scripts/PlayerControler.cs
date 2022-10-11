using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    public GameObject bullet;
    public Transform Spawnbullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2 ( mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-Vector2.up * Time.deltaTime * moveSpeed);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, Spawnbullet.position, transform.rotation);
        }
    }
}
