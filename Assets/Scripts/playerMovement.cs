using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Vi skal bruge "InputSystem" libary.

public class playerMovement : MonoBehaviour
{
    private Vector2 movement; //Vi vil gemme det "Vector2" der kommer ind når brugeren trykker på WSAD ind på movement.
    private Rigidbody2D myBody; //Det rigidbody vi vil flytte rundt.
    private Animator myAnimator; //Vi laver en animator variable så vi kan pille ved den i koden.

    [SerializeField] private int speed = 5; //Den hastighed vores human skal flyttes rundt.
    
    private void Awake() //Awake køre kun en gang når programmet starter.
    {
        myBody = GetComponent<Rigidbody2D>(); //Vi sætter myBody rigidbody til rigidbody på den gameobject vi sidder på.
        myAnimator = GetComponent<Animator>(); //Vi vil lege med den animator den sidder på vores gameobject så derfor.
    }

    private void OnMovement(InputValue value) //Vi laver en function der holder øje med vores Input systems value.
    {
        movement = value.Get<Vector2>(); //Movement bliver sat til vector2 fra vores Input Action når brugeren trykker WSAD.

        if (movement.x != 0 || movement.y != 0) { //value.vector2 bliver sat til [0,0] når man ikke trykker på WSAD og spilleren
                                                  //kigger op konstant når vi er færdig med at trykke. For at undgå det gør vi sådan
                                                  //så vi ændre vores animation kun hvis mindst en af x eller y er ikke = 0.
            myAnimator.SetFloat("x", movement.x); //Sætter vores x i vores animator til movement.x der kommer fra unity input.
            myAnimator.SetFloat("y", movement.y); //Sætter vores y i vores animator til movement.x der kommer fra unity input.

            myAnimator.SetBool("isWalking", true); //når enten movement.x eller y ikke er = 0 så betyder det vi walker!
        }
        else
        {
            myAnimator.SetBool("isWalking", false); //Ellers walker vi ikke så sæt den til false.
        }
    }

    private void FixedUpdate() //FixedUpdate er mere effektiv end update når det kommer til even based ting som flytning.
    {
        myBody.velocity = movement * speed; //Vi sætter velocity af vores rigidbody2D i den hastighed vi har sat.
    }
}
