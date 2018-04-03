using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [Header("PLayer Attributes")]
    public int hp;
    [Range(0,100)]
    public int hpMax=100;

    [Header("Player UI")]
    public Text hpText;
    public Image hpBar;

    public Animator anim;
    public Collider AtkCollider;

    private Player m_Player;
    public Vector3 offset;
    private float _pointY;
	public float Speed = 0.3f;
    public float damping = 5;
	//Default move speed

    public GameObject exitButton;

	// Use this for initialization
	void Start () {
		m_Player = GameObject.Find("Player").GetComponent<Player>(); 
        offset =  transform.position- m_Player.transform.position;
        anim=GetComponent<Animator>();
        hpText.text="I'm Player";
        hp =hpMax;
        hpBar.fillAmount=(float)hp/(float)hpMax;
	}
	
	// Update is called once per frame
	void Update () {
        _pointY = m_Player.transform.eulerAngles.y;
        //Debug.Log(_pointY);//0~360  
        Quaternion rotatiom = Quaternion.Euler(0, _pointY, 0);
        transform.position = Vector3.Lerp(transform.position, m_Player.transform.position + (rotatiom * offset),Time.deltaTime*damping);  
        
        transform.LookAt(m_Player.transform.position);

		       if (Input.GetKey (KeyCode.W)) {
                              gameObject.GetComponent<Transform> ().Translate (Vector3.forward * 0.05f, Space.Self);
                   }
               if (Input.GetKey (KeyCode.S)) {
                            gameObject.GetComponent<Transform> ().Translate (Vector3.back * 0.05f, Space.Self);
                   }
               if (Input.GetKey (KeyCode.A)) {
                          gameObject.GetComponent<Transform> ().Translate (Vector3.left * 0.05f, Space.Self);
                   }
               if (Input.GetKey (KeyCode.D)) {
                         gameObject.GetComponent<Transform> ().Translate (Vector3.right * 0.05f, Space.Self);
                   }
                   //jump
               if (Input.GetKey (KeyCode.Space)) {
                            gameObject.GetComponent<Transform> ().Translate (Vector3.up * Time.deltaTime * Speed);
                   }
                   //turn
               if (Input.GetKey (KeyCode.LeftArrow)) {
                            gameObject.GetComponent<Transform> ().Rotate (0f, -2f, 0f);
                   }
               if (Input.GetKey (KeyCode.RightArrow)) {
                            gameObject.GetComponent<Transform> ().Rotate (0f, 2f, 0f);
                   }
		if (Input.GetKey (KeyCode.J)) {
			anim.SetBool ("Attack", true);
            AtkCollider.GetComponent<SphereCollider>().enabled = true;
            } else {
			anim.SetBool ("Attack", false);
            AtkCollider.GetComponent<SphereCollider>().enabled = false;
			
		}
        hpBar.fillAmount=(float)hp/(float)hpMax;
    }
    void OnTriggerEnter(Collider col){
        if(col.tag=="AtkSphereEnemy"){
            if(hp>0){
                anim.SetTrigger("hit");
                hp=Mathf.Clamp(hp-5,0,hpMax);
                print("player being hit");          
            if(hp<=0){
                anim.SetBool("die",true);
                print("player die");
                exitButton.SetActive(true); 
                this.enabled=false;
            }          
        }
        }
        hpBar.fillAmount=(float)hp/(float)hpMax;
    }
    void Collider(Collider col){}
    }
