using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    public SpriteRenderer spriteRenderer;
    public Sprite Damage1;
    public Sprite Damage2;
    public Sprite Dead;
    int damage = 0;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ( player != null && damage !=3)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && damage == 0){
            spriteRenderer.sprite = Damage1;
            damage++;
        }else if (collision.CompareTag("Bullet") && damage == 1)
        {
            spriteRenderer.sprite = Damage2;
            damage++;
        }
        else if (collision.CompareTag("Bullet") && damage == 2)
        {
            spriteRenderer.sprite = Dead;
            damage++;
            Destroy(gameObject, 0.5f);
        }
        if (collision.CompareTag("Player")){
            spriteRenderer.sprite = null;
            anim.SetBool("DamagePlayer", true);
            damage = 3;
            Destroy(gameObject, 0.5f);
        }
    }
}
