using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBug : CharacterSpecifics
{
    //public vars

    //serializable private vars

    [SerializeField] private float chargeSpeed = 75f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float jumpSpeed = 30f;
    [SerializeField] private float attackEndLag = 1f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float mobilityEndLag = 1f;
    [SerializeField] private float mobilityCooldown = 2f;

    //private vars
    private UniversalMovement baseMovement;

    private Rigidbody rb;

    private bool attackAvailable = true;

    private bool mobilityAvailable = true;

    private void Start(){
        baseMovement = transform.GetComponent<UniversalMovement>();
        rb = transform.GetComponent<Rigidbody>();
    }

    public override void attack(){
        if(attackAvailable){
            StartCoroutine(attackRoutine());   
        }
    }

    public override void mobility(){
        if(mobilityAvailable){
            StartCoroutine(mobilityRoutine());   
        }
    }

    private IEnumerator attackRoutine(){
        int callback = baseMovement.disableInput();
        StartCoroutine(cooldown(new Ref<bool>(attackAvailable), attackCooldown));
        rb.AddForce(rb.velocity.normalized * chargeSpeed, ForceMode.Impulse);
        transform.forward = rb.velocity;
        yield return new WaitForSeconds(attackEndLag);
        baseMovement.enableInput(callback);
        yield break;
    }

    private IEnumerator mobilityRoutine(){
        int callback = baseMovement.disableInput();
        StartCoroutine(cooldown(new Ref<bool>(mobilityAvailable), mobilityCooldown));
        rb.AddForce((rb.velocity.normalized * jumpSpeed) + new Vector3(0,jumpHeight, 0), ForceMode.Impulse);
        //transform.forward = rb.velocity;
        yield return new WaitForSeconds(mobilityEndLag);
        baseMovement.enableInput(callback);
        yield break;
    }

    
}
