using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed;
    Animator anim;
    bool move;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (move != true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            move = true;
            spriteRenderer.sprite = null;
            anim.SetBool("DamagePlayer", true);
            Destroy(gameObject, 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
