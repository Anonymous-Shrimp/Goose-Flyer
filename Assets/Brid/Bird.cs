using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D Rigid;
    public CinemachineVirtualCamera cam;
    private float camSizeTarget;
    [Header("Movement")]
    public Vector2 normalForce;
    public Vector2 climbForce;
    public Vector2 diveForce;
    public float walkSpeed;
    public bool isGrounded = false;
    Vector3 rotate;
    public float turnMultipler = 3;
    public float maxRotate = 80;

    //other
    public bool isDead = false;

    //Controls
    private bool down;
    private bool up;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

        if (down && !isGrounded)
        {
            Rigid.AddForce(diveForce * Time.deltaTime);
        }
        else if(up)
        {
            Rigid.AddForce(climbForce * Time.deltaTime);
        }
        else if (!isGrounded)
        {
            Rigid.AddForce(normalForce * Time.deltaTime);
            
        }
        else if (isGrounded)
        {
            transform.Translate(new Vector3(2 * Time.deltaTime, 0));
        }
        if(Rigid.velocity.x > 150)
        {
            Rigid.velocity = new Vector2(150, Rigid.velocity.y);
        }
        if (Rigid.velocity.magnitude > 5)
        {
            camSizeTarget = Rigid.velocity.magnitude * 1.5f;
            if (camSizeTarget > 30)
            {
                camSizeTarget = 30;
            }
        }
        else
        {
            camSizeTarget = 5;
        }
        if (cam.m_Lens.OrthographicSize > camSizeTarget)
        {
            cam.m_Lens.OrthographicSize -= Time.deltaTime * Mathf.Abs(camSizeTarget - cam.m_Lens.OrthographicSize) / 2;

        }
        else if (cam.m_Lens.OrthographicSize < camSizeTarget)
        {
            cam.m_Lens.OrthographicSize += Time.deltaTime * Mathf.Abs(camSizeTarget - cam.m_Lens.OrthographicSize) / 2;
        }
        rotate = new Vector3(0, 0, Rigid.velocity.y * 1.5f);
        if (rotate.z > maxRotate)
        {
            rotate.z = maxRotate;
        }
        else if (rotate.z < -maxRotate)
        {
            rotate.z = -maxRotate;
        }
        transform.rotation = Quaternion.Euler(rotate);

        gameObject.SetActive(!isDead);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ded"))
        {
            isDead = true;
            
        }
        if (collision.gameObject.CompareTag("juice"))
        {
            FindObjectOfType<rewindManager>().juice += 0.2f;
            Destroy(collision.gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("ded"))
        {
            isDead = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = false;
        }
        
    }
}
