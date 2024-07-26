using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroleur : MonoBehaviour

{
    [SerializeField] private float VelocityY;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // changer truc parenthèse par numéro scène game over
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("NON");
            rb.gravityScale = rb.gravityScale * -1f;
            rb.velocity /= 2;
            //sr.flipY = !sr.flipY;
        }

            anim.SetFloat("VelocityY", rb.velocity.y);

       
        
    }
}
