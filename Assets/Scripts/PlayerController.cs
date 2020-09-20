using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

	private Animator animator;
	public bool attackBool;
	private const float attackWait = 0.75f;

	// Use this for initialization
	void Start()
	{
		this.animator = GetComponent<Animator>();
		attackBool = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && animator.GetFloat("ForwardSpeed") == 0 && animator.GetFloat("LateralSpeed") == 0)
		{
			attackBool = true;
			this.animator.SetBool("AttackMotion1", true);
			//Invoke("AttackWait", attackWait);
			StartCoroutine(wait());
		}
	}
	public void attack()
	{
		Debug.Log("Attack Ready");
	}
	void AttackWait()
    {
		attackBool = false;
		this.animator.SetBool("AttackMotion1", false);
	}

	IEnumerator wait()
    {
		Debug.Log("Wait start");
		while (attackBool == false)
        {
			yield return null;
        }
		//yield return new WaitForSeconds(attackWait);
		Debug.Log("wait end");
    }
}
