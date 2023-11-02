using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalMovement : MonoBehaviour
{
    //public vars

    public int playerNum = 1;

    //serializeable private vars

    [SerializeField] 
    private float acceleration = 1;

    [SerializeField] 
    private float maxVelocity = 1;

    [SerializeField] 
    private float turnSpeed = 1;

    //private vars

    private CharacterSpecifics charSpecifics;

    private Dictionary<string,KeyCode> inputs = new Dictionary<string,KeyCode>();

    private Rigidbody rb;

    private float sqrMaxVelocity;

    private int actionabilityCallback = 0;

    private bool actionable = true;
    // Start is called before the first frame update
    void Start()
    {
        charSpecifics = transform.GetComponent<CharacterSpecifics>();
        rb = transform.GetComponent<Rigidbody>();
        sqrMaxVelocity = maxVelocity * maxVelocity;
        //set player controls
        switch(playerNum){
            case 1:
                inputs.Add("up",KeyCode.W);
                inputs.Add("left",KeyCode.A);
                inputs.Add("down",KeyCode.S);
                inputs.Add("right",KeyCode.D);
                inputs.Add("attack",KeyCode.E);
                inputs.Add("mobility",KeyCode.Q);
                break;

            case 2:
                inputs.Add("up",KeyCode.Y);
                inputs.Add("left",KeyCode.G);
                inputs.Add("down",KeyCode.H);
                inputs.Add("right",KeyCode.J);
                inputs.Add("attack",KeyCode.U);
                inputs.Add("mobility",KeyCode.T);
                break;

            case 3:
                inputs.Add("up",KeyCode.P);
                inputs.Add("left",KeyCode.L);
                inputs.Add("down",KeyCode.Semicolon);
                inputs.Add("right",KeyCode.Quote);
                inputs.Add("attack",KeyCode.LeftBracket);
                inputs.Add("mobility",KeyCode.O);
                break;
            
            default:
                Debug.Log("invalid player num");
                break;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!actionable){
            return;
        }

        //dont allow input while airborne
        if(transform.position.y > 0.3f){
            return;
        }

        //read inputs
        float xInput = 0;
        float yInput = 0;
        if(Input.GetKey(inputs["up"])){
            yInput += 1;
        }
        if(Input.GetKey(inputs["down"])){
            yInput -= 1;
        }
        if(Input.GetKey(inputs["right"])){
            xInput += 1;
        }
        if(Input.GetKey(inputs["left"])){
            xInput -= 1;
        }
        if(Input.GetKey(inputs["attack"])){
            charSpecifics.attack();
        }
        if(Input.GetKey(inputs["mobility"])){
            charSpecifics.mobility();
        }

        //slow down movement on diagonals
        if(xInput != 0 && yInput != 0){
            xInput = xInput/Mathf.Sqrt(2);
            yInput = yInput/Mathf.Sqrt(2);
        }

        //set rotation to movement direction, exclude y from calculation
        if(xInput != 0 || yInput != 0){            
            Vector3 tempDir = new Vector3(xInput, 0, yInput);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, tempDir, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        //apply force
        Vector3 moveVector = new Vector3(xInput, 0, yInput);
        Vector3 force = moveVector*Time.deltaTime*acceleration;
        rb.AddForce(force, ForceMode.Impulse);

        //velocity resriction
        var v = rb.velocity;
        if(v.sqrMagnitude > sqrMaxVelocity){
            rb.velocity = v.normalized * maxVelocity;

        }
    }

    //call this function to disable player input, it will return an int callback to use when renabling
    public int disableInput(){
        actionable = false;
        actionabilityCallback++;
        if(actionabilityCallback > 50){
            actionabilityCallback = 0;
        }
        return actionabilityCallback;
    }

    //call this function to renable, fill the int variable with the int that the disable function returned to you
    public void enableInput(int callback){
        if(callback == actionabilityCallback){
            actionable = true;
        }
    }
}
