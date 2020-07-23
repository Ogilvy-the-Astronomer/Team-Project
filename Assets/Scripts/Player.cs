using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	// movement variables
	public float scrollSensitivity;
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

	public int HealthPotions;
	public int HealthPotionTimer;
	public int BuffPotions;
	public int DefensePotions;
	public int BuffPotionTimer;
	public int DefensePotionTimer;
	public int PotionBuff;
	public int PotionDefence;

    // Statistics
    public int Health = 100;
    public int HealthMax = 100;
	public int baseDamage;
	public int baseDefence;
	public Text healthText;
	public Text healthmaxText;

	public Text ArmourText;
	public Text WeaponText;

	public Text HPotText;
	public Text BPotText;
	public Text DPotText;

    public Vector3 AttackDir;
	public bool moveAction;
	public int movecount;
	public bool standardAction;

	public AudioClip swing;
	public AudioClip hurt;
    
    Player()
    {
        t = 3 * Mathf.PI / 2; //270 degrees, forward, vector 0,0,1
		Weapon W = new Weapon();
		ItemTemplates.ConstructWeapon(ref W, 0);
		WeaponPrimary = W;
        WeaponSecondary = null;
		Armour A = new Armour();
		ItemTemplates.ConstructArmour(ref A, 0);
		ArmourPrimary = A;
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
		if (Health <= 0) {
			SceneManager.LoadScene ("Game Over");
		}
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
					movecount++;
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
					movecount++;
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
					movecount++;
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
					movecount++;
                }
				if (standardAction && moveAction) {
					if (Input.GetKeyDown (KeyCode.H) && HealthPotions > 0) {
						Health += 50;
						if (Health > HealthMax) {
							Health = HealthMax;
						}
						HealthPotions--;
						standardAction = moveAction = false;
					}
					if (Input.GetKeyDown (KeyCode.B) && BuffPotions > 0) {
						BuffPotionTimer = 30;
						BuffPotions--;
						standardAction = moveAction = false;
					}
					if (Input.GetKeyDown (KeyCode.U) && DefensePotions > 0) {
						DefensePotionTimer = 30;
						DefensePotions--;
						standardAction = moveAction = false;
					}
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
                    //moveAction = true;
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
			if (Input.GetKey(KeyCode.Q)) // Cheat key
			{
				HealthPotions++;
				BuffPotions++;
				DefensePotions++;
			}
			if (Input.mouseScrollDelta.y != 0) {
				if (Camera.main.orthographicSize > 1 && Camera.main.orthographicSize < 100) {
					Camera.main.orthographicSize -= Input.mouseScrollDelta.y * scrollSensitivity;
				} else if (Camera.main.orthographicSize <= 1) {
					Camera.main.orthographicSize = 2;
				} else if (Camera.main.orthographicSize >= 100) {
					Camera.main.orthographicSize = 99;
				}
			}
			if (Input.GetMouseButtonDown (2)) {
				Camera.main.orthographicSize = 5;
			}
            //if (Input.GetKey(KeyCode.X))
            //{
            //    Debug.Log(AttackDir.x + ", " + AttackDir.z);
            //    DelayTimer = 10;
            //} // subroutine used for testing the trigonometry of the turning
        }
        else
            DelayTimer--;
		healthText.text = Health.ToString();
		healthmaxText.text = HealthMax.ToString();
		WeaponText.text = (WeaponPrimary.Name + " " + WeaponPrimary.Damage.ToString ());
		ArmourText.text = (ArmourPrimary.Name + " " + ArmourPrimary.Resistances [0].ToString ());
		HPotText.text = (HealthPotions + " Health potions remaining.");
		DPotText.text = (DefensePotions + " Defense potions remaining.\n" + DefensePotionTimer + " turns left with defence increased.");
		BPotText.text = (BuffPotions + " Buff potions remaining.\n" + BuffPotionTimer + " turns left with attack buffed.");

		if (movecount < 50) {
			moveAction = true;
		}
	}

	public void BeginTurn(){
		moveAction = true;
		movecount = 0;
		standardAction = true;
		if (DefensePotionTimer > 1) {
			PotionDefence = 20;
			DefensePotionTimer--;
		}
		if (BuffPotionTimer > 1) {
			PotionBuff = 20;
			BuffPotionTimer--;
		}
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
		if (!GetComponentInChildren<AudioSource> ().isPlaying) {
			GetComponentInChildren<AudioSource> ().PlayOneShot (swing);
		}

		//standardAction = false;
		RaycastHit hit;
		if(Physics.Raycast (new Ray (transform.position + Vector3.up, AttackDir), out hit, 1f)){
			if (hit.collider.tag == "Enemy" || hit.collider.tag == "Boss") {
				hit.transform.gameObject.GetComponent<EnemyController> ().TakeDamage ((WeaponPrimary.Damage + baseDamage + PotionBuff)*2);
				Debug.Log ("Attack hit\n ######");
			} else if (hit.collider.tag == "Finish") {
				hit.collider.gameObject.GetComponent<EndCrystal> ().Endgame ();
			} else if (hit.collider.tag == "Lootbox") {
				hit.collider.gameObject.GetComponent<LootBox> ().DoLoot ();
			}
		}
		GetComponent<Animator> ().Play ("Attack");
		standardAction = false;
		//AttackDir = Vector3.zero;
	}
	/*
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
    */
	public void TakeDamage(float damage){
		damage = damage / 1.0f;
		damage -= ArmourPrimary.Resistances [0] + baseDefence + PotionDefence;
		if (damage > 0) {
			Health -= (int)damage;
			if (!GetComponentInChildren<AudioSource> ().isPlaying) {
				GetComponentInChildren<AudioSource> ().PlayOneShot (hurt);
			}
		}
	}
}
