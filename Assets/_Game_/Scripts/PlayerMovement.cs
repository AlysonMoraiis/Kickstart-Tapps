using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private Transform movePoint;
    [SerializeField]
    private LayerMask colliders;

    [SerializeField]
    private GameObject battleScene;

    [SerializeField]
    private Animator anim;

    Vector3 movement;

    void Start()
    {
        movePoint.parent = null;
    }


    void Update()
    {
        MovementManager();
    }

    void MovementManager()
    {
       // MovementKeys(); //Chama as funções do teclado criado pelo Alyson
        
        //Retorna true or false se foi clicado em cima da UI, caso seja falso ele chama MovementTouch()
        if (!IsMouseOverUi()) MovementTouch();
        //Se a posição do player for igual a desejada, ele não executa nada abaixo desse if
        if (transform.position == movePoint.position) 
        {
            anim.SetBool("Walking", false);
            return; 
        
        }
        //Faz a movimentação para posição desejada
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


    }

    void MovementTouch()
    {
        //Caso não seja o "botão esquerdo do mouse", ele não executa nada abaixo do if
        if (!Input.GetMouseButtonDown(0)) return;        
        //Pega a posição do clice do mouse e define a posição desejada
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f;
        movePoint.position = worldPosition;
        anim.SetBool("Walking", true);
        var toPosition = (worldPosition - transform.position).normalized;
        transform.localScale = new Vector3 (toPosition.x < 0 ? -1 : 1, 1, 1);
        Debug.Log($"to position{toPosition}");


    }

    private bool IsMouseOverUi()
    {
        //Verifica se clicou na UI
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {       
        //Se a tag do objeto for diferente de Wall, ele não executa nada abaixo
        if (!other.gameObject.CompareTag("Wall")) return;
        movePoint.position = transform.position;
        anim.SetBool("Walking", false);


    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Wall")) return;
        movePoint.position = transform.position;
        anim.SetBool("Walking", false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            battleScene.SetActive(true);
            Destroy(collision.gameObject);
            movePoint.position = transform.position;
            Debug.Log("Battle");
        }
    }
    

}

