using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private CharacterController enemyController;
    private Vector3 destination;
    [SerializeField]
    private float walkspeed = 2.0f;
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 startPosition;
    public GameObject SuitMan;
    private Vector3 manPos;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        //startPosition = transform.position;
        //var randDestination = Random.insideUnitCircle * 30;
        
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.isGrounded)
        {
            velocity = Vector3.zero;
            manPos = SuitMan.transform.position;

            direction = (manPos - transform.position).normalized;
            velocity = direction * walkspeed;
            transform.LookAt(new Vector3(manPos.x, transform.position.y, manPos.z));
            
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);
    }
}
