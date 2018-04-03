using System.Collections;
using UnityEngine;
/// <summary>
/// A class for making things jump when you make a fist using the Myo
/// </summary>
public class Jump : MonoBehaviour
{
    // Public objects can be "set" from the Unity3D Editor
    public Rigidbody Capsule;
    public ThalmicMyo Myo;
    // Keep track of our jumping state
    public bool isJumping = false;

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
            if (!isJumping && (Myo.pose == Thalmic.Myo.Pose.Fist || Input.GetKey(KeyCode.Return)))
            {
                var dir = Capsule.transform.position - Capsule.transform.GetChild(0).position * 100;
                Capsule.AddForce(dir, ForceMode.Impulse);
                isJumping = true;
            }
            else if (isJumping && (Myo.pose != Thalmic.Myo.Pose.Fist && !Input.GetKey(KeyCode.Return)))
            {
                isJumping = false;
            }
			// Adds force when the user makes a wave left or presses the enter key
            if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.WaveIn || Input.GetKey(KeyCode.A)))
            {
                // var dir = Capsule.transform.position - Capsule.transform.GetChild(0).position * 100;
                // Capsule.AddForce(dir, ForceMode.Impulse);
				gameObject.GetComponent<Transform> ().Rotate (0f, -2f, 0f);
				print("left");
                isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.WaveIn && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
			if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.WaveOut || Input.GetKey(KeyCode.A)))
            {
                // var dir = Capsule.transform.position - Capsule.transform.GetChild(0).position * 100;
                // Capsule.AddForce(dir, ForceMode.Impulse);
				print("Right");
                isWalking = true;
            }
            else if (isWalking && (Myo.pose != Thalmic.Myo.Pose.WaveOut && !Input.GetKey(KeyCode.A)))
            {
                isWalking = false;
            }
			if (!isWalking && (Myo.pose == Thalmic.Myo.Pose.FingersSpread || Input.GetKey(KeyCode.A)))
            {
                // var dir = Capsule.transform.position - Capsule.transform.GetChild(0).position * 100;
                // Capsule.AddForce(dir, ForceMode.Impulse);
				print("Right");
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