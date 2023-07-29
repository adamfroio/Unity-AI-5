using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SimpleFSM : FSM
{
    public enum FSMState
    {
        None, Patrol, Chase, Attack, Dead,
    }

    // Current state that the NPC is reaching
    public FSMState currState = FSMState.Patrol;

    // Speed of the tank
    private float currSpeed = 25.0f;

    // tank rotation speed
    private float curRotSpeed = 2.0f;

    public GameObject Bullet;

    // whether the NPC Is destroyed
    private bool bDead = false;
    private int health = 100;

    // we overwrite the deprecated built-in rigidbody variable
    new private Rigidbody rigidbody;

    // player Transform
    protected Transform playerTransform;

    // next destination position of the NPC tank
    protected Vector3 destPos;

    // list of points for patrolling
    protected GameObject[] pointList;

    // bullet shooting rate
    protected float shootRate = 3.0f;
    protected float elapsedTime = 0.0f;
    public float maxFireAimError = 0.001f;

    // status radius
    public float patrollingRadius = 100.0f;
    public float attackRadius = 200.0f;
    public float playerNearRadius = 300.0f;

    // tank turret
    public Transform turret;
    public Transform bulletSpawnPoint;

    // initialize the state machine for the NPC tank
    protected override void Initialize()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
