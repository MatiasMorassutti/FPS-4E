using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject barreraPeligro;
    public GameObject Reintentar;
    public GameObject camara;
    public float movementSpeed, jumpForce;
    public float rotatioSpeed;
    public float velocidadBarrera;
    public Vector3 respawn = new Vector3(0,0.5f,0);
    bool hasJump;
    Rigidbody rb;
   
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hasJump = true;
        Reintentar.gameObject.SetActive(false);
        camara.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(movementSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-movementSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotatioSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotatioSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && hasJump)
        {
            hasJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if(gameObject.transform.position != new Vector3 (4, 0.5f, 0))
        {
            barreraPeligro.transform.Translate(0, velocidadBarrera, 0);
        }

    }



    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Toco");
       if (col.gameObject.tag == "DeathWall")
       {            
            camara.SetActive(true);
            gameOver.SetActive(true);
            Reintentar.gameObject.SetActive(true);
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Ground")
        {
            hasJump = true;
        }
        if (col.gameObject.name == "Llegada Total")
        {
            transform.position = new Vector3(3.93f, 0.5f, 0);
            barreraPeligro.transform.position = new Vector3(16.6f, 1.3f, 0);
        }
    }
}