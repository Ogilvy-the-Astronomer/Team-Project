using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement related variables
	public float moveSpeed;
	public float sensitivity;
	public float jumpForce;
	public GameObject root;
    Animator myAnim;

    // Equipment slots
    public Weapon WeaponPrimary;
    public Item WeaponSecondary;
    public Armour ArmourPrimary;
    public Item[] MiscSlots; // 5 misc slots
    public List<Item> Inventory;

    // Statistics
    public int Health = 100;
    public int HealthMax = 100;

    public bool moveAction;
	public bool standardAction;

    PlayerController()
    {
        MiscSlots = new Item[5];
        for (int i = 0; i < MiscSlots.Length; i++)
        {
            MiscSlots[i] = new Item();
        }
    }

	// Use this for initialization
	void Start () {
		moveAction = true;
		standardAction = true;
        Health = 100;
        myAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveAction)
        {
            if (Input.GetKeyDown(KeyCode.W) && !Physics.Raycast(new Ray(transform.position, transform.forward), 1f))
            {
                transform.Translate(transform.forward);
                //moveAction = false;
                Debug.Log("Player moved");
            }
            if (Input.GetKeyDown(KeyCode.S) && !Physics.Raycast(new Ray(transform.position, -transform.forward), 1f))
            {
                transform.Translate(-transform.forward);
                //moveAction = false;
                Debug.Log("Player moved");
            }
            if (Input.GetKeyDown(KeyCode.D) && !Physics.Raycast(new Ray(transform.position, transform.right), 1f))
            {
                transform.Translate(transform.right);
                //moveAction = false;
                Debug.Log("Player moved");
            }
            if (Input.GetKeyDown(KeyCode.A) && !Physics.Raycast(new Ray(transform.position, -transform.right), 1f))
            {
                transform.Translate(-transform.right);
                //moveAction = false;
                Debug.Log("Player moved");
            }
        }
        if (Health == 0)
            {
                myAnim.SetBool("isDead", true);
            }
	}

	public void BeginTurn() {
		moveAction = true;
		standardAction = true;
	}

	public void AttackUp(){
		if (standardAction) {
			Debug.Log ("Attack up");
			//standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, transform.forward), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
	public void AttackRight(){
		if (standardAction) {
			Debug.Log ("Attack left");
			//standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, -transform.right), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
	public void AttackDown(){
		if (standardAction) {
			Debug.Log ("Attack down");
			//standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, -transform.forward), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
	public void AttackLeft(){
		if (standardAction) {
			Debug.Log ("Attack right");
			//standardAction = false;
			RaycastHit hit;
			Physics.Raycast (new Ray (transform.position, transform.right), out hit, 1f);
			hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage (5);
		}
	}
}
