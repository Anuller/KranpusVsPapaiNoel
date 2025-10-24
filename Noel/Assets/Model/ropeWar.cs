using System;
using UnityEngine;
using UnityEngine.UI;

public class ropeWar : MonoBehaviour
{
    Rigidbody body;
    public Rigidbody opponent;

    public float forcaBase = 3f;
    float forcaAtual;
    public float velocidadeDeVariacao = 1f;

    public bool canPlayer1, canPlayer2;

    public Button sprit;
    public Sprite normalSprite;
    public Sprite pressedSprite;

    private Image buttonImage;

    void Awake()
    {
        buttonImage = sprit.GetComponent<Image>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        forcaAtual = forcaBase + Mathf.Sin(Time.time * velocidadeDeVariacao) * 2f;

        if (canPlayer1 == true)
        {
            if (Input.GetButtonDown("E"))
            {
                ButtonForcePlayer1();
                buttonImage.sprite = pressedSprite;
            }

            if (Input.GetButtonUp("E"))
            {
                buttonImage.sprite = normalSprite;
            }
        }

        if (canPlayer2 == true)
        {
            if (Input.GetButtonDown("L"))
            {
                ButtonForcePlayer2();
                buttonImage.sprite = pressedSprite;
            }

            if (Input.GetButtonUp("L"))
            {
                buttonImage.sprite = normalSprite;
            }
        }
    }

    public void ButtonForcePlayer1()
    {
        Vector3 force = new Vector3(forcaAtual, 0, 0);
        body.AddForce(force, ForceMode.Impulse);
        opponent.AddForce(force, ForceMode.Impulse);
    }

    public void ButtonForcePlayer2()
    {
        Vector3 force = new Vector3(-forcaAtual, 0, 0);
        body.AddForce(force, ForceMode.Impulse);
        opponent.AddForce(force, ForceMode.Impulse);
    }
}