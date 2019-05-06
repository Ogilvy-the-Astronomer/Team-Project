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
    int DelayTimer;
    float t; // parameter for a parametric circle equation

	// equipment variables
	public Weapon WeaponPrimary;
	public Item WeaponSecondary;
	public Armour ArmourPrimary;
    public Item[] MiscSlots; // 5 misc slots
    public List<Item> Inventory;

    public GameObject InvPanel; // inventory panel
    public GameObject InvPanelBag;
    public GameObject InvPanelMisc;
    public GameObject WeaponPrimaryButton;
    public GameObject WeaponSecondaryButton;
    public GameObject ArmourPrimaryButton;

    // Statistics
    public int Health = 100;
    public int HealthMax = 100;

    public Vector3 AttackDir;
	public bool moveAction;
	public bool standardAction;
    
    Player()
    {
        t = 3 * Mathf.PI / 2; //270 degrees, forward, vector 0,0,1
        WeaponPrimary = null;
        WeaponSecondary = null;
        ArmourPrimary = null;
        MiscSlots = new Item[5];
        for (int i = 0; i < MiscSlots.Length; i++)
        {
            MiscSlots[i] = null;
        }
        Inventory = new List<Item>();
        // debug stuff --------------------------------------------------------------------
        Weapon W = new Weapon();
        ItemTemplates.ConstructWeapon(ref W, 0);
        Inventory.Add(W);
        for (int i = 0; i < 3; i++)
        {
            
            W = new Weapon();
            ItemTemplates.ConstructWeapon(ref W, 1);
            Inventory.Add(W);
        }
        // -----------------------------------------------------------------------
        //InventoryPanel.
        InvPanelBagFill();
    }

	void Start ()
    {
		moveAction = true;
		standardAction = true;
		isMoving = false;
        TurningTime = 0;
        DelayTimer = 0;
	}
	void Update ()
    {
        if (DelayTimer == 0)
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
                    t = 3 * Mathf.PI / 2;
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
                    t = Mathf.PI / 2;
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
                    t = 0;
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
                    t = Mathf.PI;
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
                    DelayTimer = 20;
                    TurningTime = 0;
                    t -= Mathf.PI / 4;
                    AttackDir = new Vector3(Mathf.Cos(t), 0, -Mathf.Sin(t));
                }
                if (Input.GetKey(KeyCode.D))
                {
                    root.transform.Rotate(0, 45, 0);
                    DelayTimer = 20;
                    TurningTime = 0;
                    t += Mathf.PI / 4;
                    AttackDir = new Vector3(Mathf.Cos(t), 0, -Mathf.Sin(t));
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
            if (Input.GetKey(KeyCode.I)) // Inventory key
            {
                InvPanel.SetActive(!InvPanel.activeSelf);
                DelayTimer = 20; // needed a delay again so I used the same variable lol -Michał
            }
            //if (Input.GetKey(KeyCode.X))
            //{
            //    Debug.Log(AttackDir.x + ", " + AttackDir.z);
            //    DelayTimer = 10;
            //} // subroutine used for testing the trigonometry of the turning
        }
        else
            DelayTimer--;
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

    void InvPanelBagFill()
    {
        while (InvPanelBag.transform.childCount > 0)
        {
            Transform T = InvPanelBag.transform.GetChild(0);
            Destroy(T.gameObject);
        }
        for (int i = 0; i < Inventory.Count; i++)
        {
            
            InvButtonScript button = new InvButtonScript();
            button.transform.SetParent(InvPanelBag.transform);
            button.SetFields(Inventory[i].Name, Inventory[i]);
        }
    }
}
