using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControler : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    public GameObject bullet;
    public GameObject bulletLeft;
    public GameObject bulletRight;
    public Transform Spawnbullet;
    public Transform SpawnBulletRight1;
    public Transform SpawnBulletRight2;
    public Transform SpawnBulletRight3;
    public Transform SpawnBulletLeft1;
    public Transform SpawnBulletLeft2;
    public Transform SpawnBulletLeft3;
    public SpriteRenderer spriteRenderer;
    public Sprite Damage1;
    public Sprite Damage2;
    public Sprite Dead;
    public static float Health;
    int damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        Health = 90.0f;
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
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(bulletRight, SpawnBulletRight1.position, transform.rotation);
            Instantiate(bulletRight, SpawnBulletRight2.position, transform.rotation);
            Instantiate(bulletRight, SpawnBulletRight3.position, transform.rotation);
            Instantiate(bulletLeft, SpawnBulletLeft1.position, transform.rotation);
            Instantiate(bulletLeft, SpawnBulletLeft2.position, transform.rotation);
            Instantiate(bulletLeft, SpawnBulletLeft3.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet")) && damage == 0)
        {
            Health -= 30.0f;
            spriteRenderer.sprite = Damage1;
            damage++;
        }
        else if ((collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet")) && damage == 1)
        {
            Health -= 30.0f;
            spriteRenderer.sprite = Damage2;
            damage++;
        }
        else if ((collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet")) && damage == 2)
        {
            Health -= 30.0f;
            spriteRenderer.sprite = Dead;
            damage++;
            Destroy(gameObject, 0.5f);
            SceneManager.LoadScene("GameOver");
        }
    }
}
