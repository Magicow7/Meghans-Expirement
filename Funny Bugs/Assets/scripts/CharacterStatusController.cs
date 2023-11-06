using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusController : MonoBehaviour
{
    UniversalMovement baseMovement;
    [SerializeField] private int _maxHealth;
    public int MaxHealth { get => _maxHealth; }
    public int Health { get; private set; }

    void Start() {
        baseMovement = transform.GetComponent<UniversalMovement>();
        Health = MaxHealth;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage) {
        Health -= damage;
        if (Health <= 0) {
            Die();
        }
    }

    void Die() {
        baseMovement.disableInput();
    }
}
