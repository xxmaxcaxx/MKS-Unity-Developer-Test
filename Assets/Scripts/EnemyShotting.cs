using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotting : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    public SpriteRenderer spriteRenderer;
    public Sprite Damage1;
    public Sprite Damage2;
    public Sprite Dead;
    int damage = 0;
    Animator anim;
    public GameObject bullet;
    public Transform Spawnbullet;
    private float nextfireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && damage != 3)
        {
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            if (dir.x <  3.5f && dir.y < 3.5f)
            {
                if(nextfireTime < Time.time)
                {
                    Instantiate(bullet, Spawnbullet.position, transform.rotation);
                    nextfireTime = Time.time + 1.0f;
                }
            }
            else
            {
                transform.Translate(-Vector2.up * Time.deltaTime * speed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && damage == 0)
        {
            spriteRenderer.sprite = Damage1;
            damage++;
        }
        else if (collision.CompareTag("Bullet") && damage == 1)
        {
            spriteRenderer.sprite = Damage2;
            damage++;
        }
        else if (collision.CompareTag("Bullet") && damage == 2)
        {
            spriteRenderer.sprite = Dead;
            damage++;
            GameSession.points++;
            Destroy(gameObject, 0.5f);
        }
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = null;
            anim.SetBool("DamagePlayer", true);
            damage = 3;
            Destroy(gameObject, 0.5f);
        }
    }
}
