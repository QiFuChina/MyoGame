using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// using LockingPolicy = Thalmic.Myo.LockingPolicy;
// using Pose = Thalmic.Myo.Pose;
// using UnlockType = Thalmic.Myo.UnlockType;
// using VibrationType = Thalmic.Myo.VibrationType;

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

    // public GameObject myo = null;
    // private Pose _lastPose = Pose.Unknown;
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
        #region Keyboard Controller Script
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
        #endregion 	
        
        // ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
        // if (thalmicMyo.pose != _lastPose) {
        //     _lastPose = thalmicMyo.pose;
        //     if (thalmicMyo.pose == Pose.Fist) {
        //                 gameObject.GetComponent<Transform> ().Translate (Vector3.forward * 0.05f, Space.Self);
        //                 ExtendUnlockAndNotifyUserAction (thalmicMyo);
        //            }
        //     if (thalmicMyo.pose == Pose.WaveIn) {
        //                 gameObject.GetComponent<Transform> ().Translate (Vector3.back * 0.05f, Space.Self);
        //                 ExtendUnlockAndNotifyUserAction (thalmicMyo);
        //            }
        //     if (thalmicMyo.pose == Pose.WaveOut) {
        //                 gameObject.GetComponent<Transform> ().Translate (Vector3.left * 0.05f, Space.Self);
        //                 ExtendUnlockAndNotifyUserAction (thalmicMyo);
        //            }
        //     if (thalmicMyo.pose == Pose.DoubleTap) {
        //                 gameObject.GetComponent<Transform> ().Translate (Vector3.right * 0.05f, Space.Self);
        //                 ExtendUnlockAndNotifyUserAction (thalmicMyo);
        //            }
        // }
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

    // void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
    // {
    //     ThalmicHub hub = ThalmicHub.instance;

    //     if (hub.lockingPolicy == LockingPolicy.Standard) {
    //         myo.Unlock (UnlockType.Timed);
    //     }

    //     myo.NotifyUserAction ();
    // }
    void Collider(Collider col){}
    }
