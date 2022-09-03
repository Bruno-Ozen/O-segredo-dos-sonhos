using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSofia : MonoBehaviour
{
    // Start is called before the first frame update
    //Movimentação
    public Rigidbody2D sofiaBody;
    //Animação
    public Animator animaSofia;
    //Sistema de pulo
    public bool liberaPulo;
    public Transform check;
    public LayerMask oqEChao;
    public float raio = 0.2f;
    public float puloForca = 2f;
    bool face = true;
    void Start()
    {
        sofiaBody = GetComponent<Rigidbody2D>();
        animaSofia = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //O que é chão
        liberaPulo = Physics2D.OverlapCircle(check.position, raio, oqEChao);
        if(liberaPulo == true)
        {
            animaSofia.SetBool("estanochao", true);
        }
        else
        {
            animaSofia.SetBool("estanochao", false);
        }
        //MOVIMENTAÇÃO
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            Correr(-0.03f);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) {
            Correr(0.03f);
        }else if (Input.GetKey(KeyCode.A))
        {
            Andar(-0.015f);
        }else if (Input.GetKey(KeyCode.D))
        {
            Andar(0.015f);
        }
        else if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animaSofia.SetBool("idle", true);
            animaSofia.SetBool("correr", false);
            animaSofia.SetBool("andar", false);
        }
        //Pulo
        if (Input.GetKeyDown(KeyCode.Space) && liberaPulo == true && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            sofiaBody.AddForce(new Vector2(0, puloForca), ForceMode2D.Impulse);
            animaSofia.SetBool("pular", true);
            animaSofia.SetBool("correr", false);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && liberaPulo == true && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            sofiaBody.AddForce(new Vector2(0, puloForca), ForceMode2D.Impulse);
            animaSofia.SetBool("pular", true);
            animaSofia.SetBool("correr", false);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && liberaPulo == true && Input.GetKey(KeyCode.A))
        {
            sofiaBody.AddForce(new Vector2(0, puloForca), ForceMode2D.Impulse);
            animaSofia.SetBool("pular", true);
            animaSofia.SetBool("andar", false);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && liberaPulo == true && Input.GetKey(KeyCode.D))
        {
            sofiaBody.AddForce(new Vector2(0, puloForca), ForceMode2D.Impulse);
            animaSofia.SetBool("pular", true);
            animaSofia.SetBool("andar", false);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && liberaPulo == true)
        {
            sofiaBody.AddForce(new Vector2(0, puloForca), ForceMode2D.Impulse);
            animaSofia.SetBool("pular", true);
            animaSofia.SetBool("idle", false);
        }
        //FLIP
        if (Input.GetKey(KeyCode.D) && !face)
        {
            Flip();
            face = true;
        }else if(Input.GetKey(KeyCode.A) && face)
        {
            Flip();
            face = false;
        }
    }
    void Correr(float velocidade)
    {
        sofiaBody.transform.Translate(new Vector2(velocidade, 0));
        animaSofia.SetBool("correr", true);
        animaSofia.SetBool("idle", false);
        animaSofia.SetBool("andar", false);
    }
    void Andar(float velocidade)
    {
        sofiaBody.transform.Translate(new Vector2(velocidade, 0));
        animaSofia.SetBool("correr", false);
        animaSofia.SetBool("idle", false);
        animaSofia.SetBool("andar", true);
    }
    void Flip()
    {
        sofiaBody.transform.localScale = new Vector3(-sofiaBody.transform.localScale.x, sofiaBody.transform.localScale.y, sofiaBody.transform.localScale.z);
    }
}
