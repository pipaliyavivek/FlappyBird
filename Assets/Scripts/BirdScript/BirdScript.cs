  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance;
    public int Score;
    private Rigidbody2D  rb;
    [SerializeField ]
    private Animator anim;

    private float forwardSpeed=3f;
    private float BounceSpeed=4f;

    private bool didFlap;
    public bool isAlive;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flapClip,pointClip,diedClip;
    private void Awake()
    {
        Score = 0;
        isAlive = true;
       if(instance == null )
        {
            instance = this;
        }
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        SetCameraX();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;
            if (didFlap)
            {
                didFlap = false;
                rb.velocity = new Vector2(0, BounceSpeed);
                anim.SetTrigger("Flap");
            }
            if(rb.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -rb.velocity.y / 7);
            //    Debug.Log(angle);
                transform.rotation = Quaternion.Euler(0, 0, angle );

            }
        }
        
    }
    void SetCameraX()
    {
        CameraScripts.offsetX = (Camera.main.transform.position.x - transform.position.x)-1f;
    }
    public float GetPositionX()
    {
        return transform.position.x;
    }
    public void FlapTheBird()
    {
       // Debug.Log("FunctionCalledSccessfuly...");
        didFlap = true;
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if( target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe")
        {
            //Debug.Log("Ground And Pipe Tag Finded");

            if (isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Died");
                audioSource.PlayOneShot(diedClip);
                GamePlayControllar.instance.PlayerDiedShowScore(Score);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pipe Holder")
        {
            Score++;
            Debug.Log("score Value:" + Score);
            GamePlayControllar.instance.SetScore(Score);
            audioSource.PlayOneShot(pointClip);
        }
    }
}
