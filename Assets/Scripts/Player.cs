using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// movement variables
	public float moveSpeed;
	public float sensitivity;
	public float jumpForce;
	public GameObject root;
	public bool isMoving;
	public Vector3 MoveDir;
	float moveCounter;
    int TurningTime;
    int TurningDelay;

	// equipment variables
	public Weapon WeaponPrimary;
	public Item WeaponSecondary;
	public Armour ArmourPrimary;
    public Item[] MiscSlots; // 5 misc slots
    public List<Item> Inventory;

    // Statistics
    public int Health = 100;
    public int HealthMax = 100;

    public Vector3 AttackDir;
	public bool moveAction;
	public bool standardAction;

    Player()
    {
        WeaponPrimary = null;
        WeaponSecondary = null;
        ArmourPrimary = null;
        MiscSlots = new Item[5];
        for (int i = 0; i < MiscSlots.Length; i++)
        {
            MiscSlots[i] = null;
        }
        Inventory = new List<Item>();
    }

	void Start ()
    {
		moveAction = true;
		standardAction = true;
		isMoving = false;
        TurningTime = 0;
        TurningDelay = 0;
	}
	
	void Update ()
    {
        if (TurningDelay == 0)
        {
            Camera.main.transform.position = transform.position + new Vector3(0, 75, 0);
            if (moveAction && TurningTime == 0)
            {
                if (Input.GetKey(KeyCode.W) && !Physics.Raycast(new Ray(transform.position + Vector3.up, Vector3.forward), 1f))
                {
                    //transform.Translate (Vector3.forward);
                    moveAction = false;
                    MoveDir = Vector3.forward;
                    isMoving = true;
                    root.transform.eulerAngles = new Vector3(0, 0, 0);
                    AttackDir = Vector3.forward;
                    //Debug.Log ("Player moved");
                }
                if (Input.GetKey(KeyCode.S) && !Physics.Raycast(new Ray(transform.position + Vector3.up, -Vector3.forward), 1f))
                {
                    //transform.Translate (-Vector3.forward);
                    moveAction = false;
                    MoveDir = -Vector3.forward;
                    isMoving = true;
                    root.transform.eulerAngles = new Vector3(0, 180, 0);
                    AttackDir = Vector3.back;
                    //Debug.Log ("Player moved");
                }
                if (Input.GetKey(KeyCode.D) && !Physics.Raycast(new Ray(transform.position + Vector3.up, Vector3.right), 1f))
                {
                    //transform.Translate (Vector3.right);
                    moveAction = false;
                    MoveDir = Vector3.right;
                    isMoving = true;
                    root.transform.eulerAngles = new Vector3(0, 90, 0);
                    AttackDir = Vector3.right;
                    //Debug.Log ("Player moved");
                }
                if (Input.GetKey(KeyCode.A) && !Physics.Raycast(new Ray(transform.position + Vector3.up, -Vector3.right), 1f))
                {
                    //transform.Translate (-Vector3.right);
                    moveAction = false;
                    MoveDir = -Vector3.right;
                    isMoving = true;
                    root.transform.eulerAngles = new Vector3(0, 270, 0);
                    AttackDir = Vector3.left;
                    //Debug.Log ("Player moved");
                }
            }
            if (isMoving)
            {
                if (moveCounter < 1 / moveSpeed)
                {
                    GetComponent<Animator>().SetBool("isRunning", true);
                    transform.Translate(MoveDir / (1 / moveSpeed));
                    moveCounter++;

                }
                else
                {
                    isMoving = false;
                    GetComponent<Animator>().SetBool("isRunning", false);
					transform.position = new Vector3 (Mathf.Round (transform.position.x), transform.position.y, Mathf.Round (transform.position.z));
                    moveAction = true;
                    moveCounter = 0;
                }
            }
            if (TurningTime > 0) // Rotation (after pressing the rotation key)
            {
                TurningTime--;
                if (Input.GetKey(KeyCode.A))
                {
                    root.transform.Rotate(0, -45, 0);
                    TurningDelay = 20;
                    TurningTime = 0;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    root.transform.Rotate(0, 45, 0);
                    TurningDelay = 20;
                    TurningTime = 0;
                }
            }
            if (Input.GetKey(KeyCode.Z)) // Attack key
            {
                if (standardAction)
                {
                    Attack();
                }
            }
            if (Input.GetKey(KeyCode.C)) // Rotation key
            {
                TurningTime = 15;
            }
        }
        else
            TurningDelay--;
	}

	public void BeginTurn(){
		moveAction = true;
		standardAction = true;
	}
    #region old attack subroutines
    public void AttackUp(){
		if (standardAction) {
			//Debug.Log ("Attack up");
			AttackDir = Vector3.forward;
			Attack ();
		}
	}
	//yes I'm aware that attck right sets the attack direction to left and visa versa, for some reason that's the only way it works. Don't rename the functions cuz they correspond to which button calls them
	public void AttackRight(){
		if (standardAction) {
			Attack ();
			AttackDir = Vector3.left;
			//Debug.Log ("Attack left");
		}
	}
	public void AttackDown(){
		if (standardAction) {
			Attack ();
			AttackDir = Vector3.back;
			//Debug.Log ("Attack down");
		}
	}
	public void AttackLeft(){
		if (standardAction) {
			Attack ();
			AttackDir = Vector3.right;
			//Debug.Log ("Attack right");
		}
	}
    #endregion
    void Attack(){
		//standardAction = false;
		RaycastHit hit;
		if(Physics.Raycast (new Ray (transform.position + Vector3.up, AttackDir), out hit, 1f)){
			if (hit.collider.tag == "Enemy") {
				hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
				Debug.Log ("Attack hit\n ######");
			}
		}
		GetComponent<Animator> ().Play ("Attack");
		AttackDir = Vector3.zero;
	}
}
