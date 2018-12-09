using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class ballBehavior : MonoBehaviour
{

   public float maxSpeed = 150; //max speed ball can reach
   public float minSpeed = 0; //min speed it can go to
   public float speed = 0; //speed of ball
   public float acceleration = 2; //acceleration of the ball as you go forward
   public float turn; //turn amount
   public float massBall = 25; //mass of the ball as it grows
   private float collectMass = 2; //mass of collectables 
   public Bounds bounds;
   public SphereCollider originalBallDiameter;
   public float ballTimer = 0f;
   public float fastTimer = 0f;
   private Rigidbody rb;

   public GameObject curGameObject;
   public LastObjectDisplay lod;
   public Transform cameraPos;
   
   
   //public readonly List<KatamariObject> attachedObjects = new List<KatamariObject>();

   public GameObject mainCamera;

   
   


   void Start ()
   {
      rb = GetComponent<Rigidbody>(); //getting rigidbody of ball
      bounds = new Bounds(transform.position, originalBallDiameter.bounds.size);
   }

   

   void FixedUpdate ()
   {
      Vector3 fromCameraToMe = transform.position - mainCamera.transform.position;
      fromCameraToMe.y = 0; // First, zero out any vertical component, so the movement plane is always horizontal.
      fromCameraToMe.Normalize();
      
      
      
      
      
      ballTimer += Time.deltaTime;
      //Debug.Log(massBall);
      //Debug.Log(massBall); //printing out the mass that has been added to the ball
      float moveHorizontal = Input.GetAxis ("Horizontal"); //moving left and right
      float moveVertical = Input.GetAxis ("Vertical"); //moving up and down
      float RotateVertical = Input.GetAxis("Rotate");
      
      
      Vector3 movement = (fromCameraToMe * moveVertical + mainCamera.transform.right * moveHorizontal);
      //Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
      if (Input.GetKey((KeyCode.UpArrow)) || Input.GetKey((KeyCode.DownArrow))|| Input.GetKey((KeyCode.RightArrow)) || Input.GetKey((KeyCode.LeftArrow)) || Input.GetKey((KeyCode.W))|| Input.GetKey((KeyCode.A)) || Input.GetKey((KeyCode.S)) || Input.GetKey((KeyCode.D)))
      {
         speed = acceleration + speed;
      }
      else
      {
         speed = speed - acceleration;
      }

      if (ballTimer > 15 && Input.GetKey(KeyCode.Space)) //speed up when pressing space
      {
         fastTimer += Time.deltaTime;
         maxSpeed = 175;
         speed += 30;
         
      }
      else
      {
         maxSpeed = 120;
      }

      if (fastTimer > 5)
      {
         maxSpeed = 120;
         fastTimer = 0;
         ballTimer = 0;
      }
      
      
      //Debug.Log(speed);
      rb.AddForce (movement * speed); //how the ball is able to roll
      rb.AddTorque(transform.up * turn * moveHorizontal);// ball turn and roll
      if (speed >= maxSpeed)
      {
         speed = maxSpeed;
      }

      if (speed <= minSpeed)
      {
         speed = minSpeed;
      }

      bounds.center = transform.position;

   }

// void OnCollisionEnter(Collision col)
// {
//    if (col.gameObject.tag == "collectable") //if ball runs into an object
//    {
//       if (massBall < 35 && col.rigidbody.mass < 3)
//       {
//          
//          //rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
//          massBall += col.rigidbody.mass;
//          //massBall += collectMass; //mass collected is added to variable
//          Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
//          col.transform.parent = transform; //parenting object to ball
//          //maxSpeed += 5;
//          bounds.Encapsulate(transform.localScale + col.transform.localScale);
//          //originalBallDiameter.radius += 0.2f;
//          col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
//          col.gameObject.GetComponent<BoxCollider>().enabled = false;
//          col.gameObject.GetComponent<SphereCollider>().enabled = true;
//          originalBallDiameter.radius += 0.1f;
//       }
//
//       if (massBall > 34 && rb.mass < 60 && col.rigidbody.mass < 7)
//       {
//          //rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
//          massBall += col.rigidbody.mass;
//          //massBall += collectMass; //mass collected is added to variable
//          Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
//          col.transform.parent = transform; //parenting object to ball
//          //maxSpeed += 20;
//          bounds.Encapsulate(transform.localScale + col.transform.localScale);
//          col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
//          col.gameObject.GetComponent<BoxCollider>().enabled = false;
//          col.gameObject.GetComponent<SphereCollider>().enabled = true;
//          originalBallDiameter.radius += 0.1f;
//
//
//
//
//       }
//       if (massBall > 60 && rb.mass < 100 && col.rigidbody.mass < 15)
//       {
//          massBall += col.rigidbody.mass;
//          //rb.mass += col.rigidbody.mass; //mass of ball is now added to mass of collectable
//          //massBall += collectMass; //mass collected is added to variable
//          Destroy(col.rigidbody); //getting rid of the rigidbody on collectable
//          col.transform.parent = transform; //parenting object to ball
//          //maxSpeed += 40;
//          bounds.Encapsulate(transform.localScale + col.transform.localScale);
//          col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
//          col.gameObject.GetComponent<BoxCollider>().enabled = false;
//          col.gameObject.GetComponent<SphereCollider>().enabled = true;
//          originalBallDiameter.radius += 0.1f;
//
//
//
//       }
//    }
//    
// }

   void OnCollisionEnter(Collision col)
   {
      if (col.gameObject.tag == "collectable")
      {
         curGameObject = col.gameObject;
         //bounds.Encapsulate(bounds.center + transform.localScale +  transform.InverseTransformPoint(col.rigidbody.ClosestPointOnBounds(transform.localPosition)));
         //bounds.Encapsulate(bounds.center + transform.localScale + col.transform.localScale);
         //bounds.Encapsulate(bounds.center + col.gameObject.GetComponent<BoxCollider>().size);
         // proper bounds: bounds.Encapsulate(new Bounds(col.transform.position, col.gameObject.GetComponent<BoxCollider>().size));
         //bounds.Encapsulate(new Bounds(col.transform.position, col.gameObject.GetComponent<Renderer>().bounds.size));

         if (massBall < 35 && col.rigidbody.mass < 3 && col.rigidbody.mass < rb.mass)
         {

            //rb.mass += col.rigidbody.mass;
            massBall += col.rigidbody.mass;
            Destroy(col.rigidbody);
            col.transform.parent = transform;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
         }

         if (massBall > 34 && col.rigidbody.mass < 7 && col.rigidbody.mass < rb.mass)
         {
            //bounds.Encapsulate(transform.localScale + col.transform.localScale);
            //rb.mass += col.rigidbody.mass;
            massBall += col.rigidbody.mass;
            Destroy(col.rigidbody);
            col.transform.parent = transform;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
         }

         if (massBall > 60 && col.rigidbody.mass < 15 && col.rigidbody.mass < rb.mass)
         {
            //bounds.Encapsulate(transform.localScale + col.transform.localScale);
            //rb.mass += col.rigidbody.mass;
            massBall += col.rigidbody.mass;
            Destroy(col.rigidbody);
            col.transform.parent = transform;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
         }

         if (massBall > 100 && col.rigidbody.mass < 35 && col.rigidbody.mass < rb.mass)
         {
            //bounds.Encapsulate(transform.localScale + col.transform.localScale);
            //rb.mass += col.rigidbody.mass;
            massBall += col.rigidbody.mass;
            Destroy(col.rigidbody);
            col.transform.parent = transform;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
         }
         
         lod.DisplayObject(curGameObject);
         
         //CalculateLocalBounds();
      }
         
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.black;
      Gizmos.DrawWireCube(bounds.center, bounds.size);
      Gizmos.color = Color.yellow;
      
      /*foreach(Renderer renderer in GetComponentsInChildren<Renderer>())
      {
         //bounds.Encapsulate(renderer.bounds);
         Gizmos.DrawWireCube(renderer.bounds.center, renderer.bounds.size);
         
      }*/

   }
   
   private void CalculateLocalBounds()
   {
      Quaternion currentRotation = this.transform.rotation;
      this.transform.rotation = Quaternion.Euler(0f,0f,0f);
 
      bounds = new Bounds(this.transform.position, Vector3.one);
 
      foreach(Renderer renderer in GetComponentsInChildren<Renderer>())
      {
         bounds.Encapsulate(renderer.bounds);
      }
 
      Vector3 localCenter = bounds.center - this.transform.position;
      bounds.center = localCenter;
      Debug.Log("The local bounds of this model is " + bounds);
 
      this.transform.rotation = currentRotation;
   }
   
   
}

