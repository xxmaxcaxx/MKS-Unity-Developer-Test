using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (collision.CompareTag("Enemy") || (collision.CompareTag("EnemyShotter")))
        {
            move = true;
            spriteRenderer.sprite = null;
            anim.SetBool("Explosion", true);
            Destroy(gameObject, 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
