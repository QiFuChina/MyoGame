using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterAI : MonoBehaviour {

	[Header("Attributes")]
	public int hp;
	[Range(0,10)]
	public int hpMax=10; 

	[Header("UI")]
	public Text hpText;
	public Slider hpSlider;

	// [Header("Animation")]
	// private Animation animation;
	// public AnimationClip idleClip;
	// public AnimationClip atkClip;
    //public AnimationClip dieClip;

	[Header("Component")]
	private Animator anim;
	private Collider col;
	private Collider atkSphereEnemy;
	private GameObject AI;
	// Use this for initialization
	private void Awake () {
		hp=hpMax;
		anim=GetComponent<Animator>();
		// animation = gameObject.GetComponent<Animation>();
        // animation.clip = idleClip;
		// col=GetComponent<CapsuleCollider>();
		atkSphereEnemy=GetComponentInChildren<SphereCollider>();		
		AI=transform.Find("AI").gameObject;
	
	}
	
	// Update is called once per frame
	#region Update
	void Update () {
		hp=Mathf.Clamp(hp,0,10);
		hpText.text=hp+"/"+hpMax;
		hpSlider.value=(float)hp/(float)hpMax;
	}
	void OnTriggerEnter(Collider col){
		if(col.tag=="AtkSphere"){
			hp-=2;
			// anim.SetBool ("atk", true);
			print("player atk");
		// anim.SetTrigger("hit");
		// animation.clip=atkClip;
		// animation.Play();
		// animation.clip=idleClip;
		// animation.Play();
		if(hp>0){
			
		}
		else{
			Die();
			AI.SetActive(false);
			// anim.SetBool ("atk", false);
		}
		}
	}
	void Die(){
		anim.SetTrigger("die");
		//col.enabled=false;	
		Destroy(gameObject,1.0f);
		
	}
	public void AtkStartEnemy(){
		//animation.clip=atkClip;
		//animation.Play();
		print("atk start");
		atkSphereEnemy.enabled=true;
	}
	public void AtkStopEnemy(){
		print("atk stop");
		atkSphereEnemy.enabled=false;
	}
	#endregion
}