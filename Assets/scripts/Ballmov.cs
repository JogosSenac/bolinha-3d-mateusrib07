using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;

public class Ballmov : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    private bool pulando;
    [SerializeField] private int countCoin = 0;
    [SerializeField] private int countCube = 0;

    public TextMeshProUGUI showCoins;
    public TextMeshProUGUI showCube;

    [SerializeField] private float velocidade;

    [SerializeField] private float powerJump;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countCoin = 0;
        countCube = 0;
        showCoins.text = "0";
        showCube.text = "0";
    }

    void NextLevel()
        {
            SceneManager.LoadScene("fase2");
            countCube = 0;
        }
    
    void Win()
    {
        SceneManager.LoadScene("win");
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        transform.position += new Vector3(-1 * moveH * velocidade * Time.deltaTime, 0, -1 * moveV * velocidade * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && pulando == false)
        {
            rb.AddForce(transform.up * powerJump, ForceMode.Impulse);
            pulando = true;
        }
        
        if(countCoin == 6 && countCube == 3)
        {
            NextLevel();
        }

        if(countCube == 5)
        {
            Win();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("lava"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("reviver");
        }
        if(other.gameObject.CompareTag("lava2"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("reviver2");
        }
        if(other.gameObject.CompareTag("coin"))
        {
            countCoin += 1;
            showCoins.text = countCoin.ToString();
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("cube"))
        {
            countCube += 1;
            showCube.text = countCube.ToString();
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("chao"))
        {
            pulando = false;
        }

    }
}
