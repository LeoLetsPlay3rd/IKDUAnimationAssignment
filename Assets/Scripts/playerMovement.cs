using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Vi skal bruge "InputSystem" libary.

public class playerMovement : MonoBehaviour
{
    private Vector2 movement; //Vi vil gemme det "Vector2" der kommer ind n�r brugeren trykker p� WSAD ind p� movement.
    private Rigidbody2D myBody; //Det rigidbody vi vil flytte rundt.
    private Animator myAnimator; //Vi laver en animator variable s� vi kan pille ved den i koden.

    [SerializeField] private int speed = 5; //Den hastighed vores human skal flyttes rundt.
    
    private void Awake() //Awake k�re kun en gang n�r programmet starter.
    {
        myBody = GetComponent<Rigidbody2D>(); //Vi s�tter myBody rigidbody til rigidbody p� den gameobject vi sidder p�.
        myAnimator = GetComponent<Animator>(); //Vi vil lege med den animator den sidder p� vores gameobject s� derfor.
    }

    private void OnMovement(InputValue value) //Vi laver en function der holder �je med vores Input systems value.
    {
        movement = value.Get<Vector2>(); //Movement bliver sat til vector2 fra vores Input Action n�r brugeren trykker WSAD.

        if (movement.x != 0 || movement.y != 0) { //value.vector2 bliver sat til [0,0] n�r man ikke trykker p� WSAD og spilleren
                                                  //kigger op konstant n�r vi er f�rdig med at trykke. For at undg� det g�r vi s�dan
                                                  //s� vi �ndre vores animation kun hvis mindst en af x eller y er ikke = 0.
            myAnimator.SetFloat("x", movement.x); //S�tter vores x i vores animator til movement.x der kommer fra unity input.
            myAnimator.SetFloat("y", movement.y); //S�tter vores y i vores animator til movement.x der kommer fra unity input.

            myAnimator.SetBool("isWalking", true); //n�r enten movement.x eller y ikke er = 0 s� betyder det vi walker!
        }
        else
        {
            myAnimator.SetBool("isWalking", false); //Ellers walker vi ikke s� s�t den til false.
        }
    }

    private void FixedUpdate() //FixedUpdate er mere effektiv end update n�r det kommer til even based ting som flytning.
    {
        myBody.velocity = movement * speed; //Vi s�tter velocity af vores rigidbody2D i den hastighed vi har sat.
    }
}
