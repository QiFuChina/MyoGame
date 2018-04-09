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

	public bool isWalking = false;
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
            if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.Fist || Input.GetKey(KeyCode.Return)))
            {
                // var dir = Capsule.transform.position - Capsule.transform.GetChild(0).position * 100;
                // Capsule.AddForce(dir, ForceMode.Impulse);
                Player.transform.Translate(Vector3.forward*1f);
                //gameObject.GetComponent<Transform> ().Translate (Vector3.forward * 0.05f, Space.Self);
                print("Forward");
                isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.Fist && !Input.GetKey(KeyCode.Return)))
            {
                isWalking = false;
            }
			// Adds force when the user makes a wave left or presses the enter key
            if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.WaveIn || Input.GetKey(KeyCode.A)))
            {
                Player.transform.Rotate(0f, -2f, 0f);
				print("Left");
                //isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.WaveIn && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
			if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.WaveOut || Input.GetKey(KeyCode.A)))
            {
                Player.transform.Rotate(0f, 2f, 0f);
				print("Right");
                //isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.WaveOut && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
			if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.FingersSpread || Input.GetKey(KeyCode.A)))
            {
                // var dir = Capsule.transform.position - Capsule.transform.GetChild(0).position * 100;
                // Capsule.AddForce(dir, ForceMode.Impulse);
                Player.transform.Translate(Vector3.back*1f);
				// gameObject.GetComponent<Transform> ().Translate (Vector3.back * 0.05f, Space.Self);
                print("Back");
                isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.FingersSpread && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}