using System.Collections;
using UnityEngine;
/// <summary>
/// A class for making things jump when you make a fist using the Myo
/// </summary>
public class Move : MonoBehaviour
{
    // Public objects can be "set" from the Unity3D Editor
    public Rigidbody Player;
    public ThalmicMyo Myo;
    // Keep track of our jumping state
    // public bool isJumping = false;


    // public Collider AtkCollider;
    // public Animator anim;

    
	public bool isWalking = false;
    public bool isattacking = false;
    // Executes on first launch
    void Start()
    {
        StartCoroutine(MoveCheck());
    }
    // Runs every 1/10th of a second to see if we need to apply force
    IEnumerator MoveCheck()
    {
        while (Application.isPlaying)
        {
            // Adds force when the user makes a fist or presses the enter key
            if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.Fist || Input.GetKey(KeyCode.W)))
            {        
                Player.transform.Translate(Vector3.forward*1f);
                print("Forward");
                isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.Fist && !Input.GetKey(KeyCode.W)))
            {
                isWalking = false;
            }
			// Adds force when the user makes a wave left or presses the enter key
            if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.WaveIn || Input.GetKey(KeyCode.A)))
            {
                Player.transform.Rotate(0f, -2f, 0f);
				print("Left");
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.WaveIn && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
			if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.WaveOut || Input.GetKey(KeyCode.A)))
            {
                Player.transform.Rotate(0f, 2f, 0f);
				print("Right");
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.WaveOut && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
			if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.FingersSpread || Input.GetKey(KeyCode.A)))
            {
                Player.transform.Translate(Vector3.back*1f);
                print("Back");
                isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.FingersSpread && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
            // if (!isattacking && (Myo.pose == Thalmic.Myo.Pose.DoubleTap || Input.GetKey(KeyCode.J)))
            // {
            //     anim.SetBool ("Attack", true);
            //     AtkCollider.GetComponent<SphereCollider>().enabled = true;
            //     print("Attack");
            //     isattacking = true;
            // }
            // else if (isattacking && (Myo.pose != Thalmic.Myo.Pose.FingersSpread && !Input.GetKey(KeyCode.J)))
            // {
            //     isattacking = false;
            // }
            yield return new WaitForSeconds(0.1f);
        }
    }
}