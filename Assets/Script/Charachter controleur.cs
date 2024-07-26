using UnityEngine;


public class Playercontroleur : MonoBehaviour

{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "obstacles")
        {
            Debug.Log("Do something else here");
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*   // move rl
           float crtMove = Input.GetAxis("Horizontal") * speed;
           rb.velocity = new Vector2(crtMove, rb.velocity.y);
           anim.SetFloat("Speed", crtMove);
           sr.flipX = crtMove < 0;
       }*/
    }
}
