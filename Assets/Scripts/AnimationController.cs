using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //以下使いますよという宣言
    private CharacterController characterController;
    private Animator animator;
    private Vector3 velocity;

    //inspectorで変更可能にする:移動速度と回転速度
    [SerializeField]private float walkSpeed = 3;
    [SerializeField]private float derSpeed = 360;
   

    // Start is called before the first frame update
    void Start()
    {
        //キャラクタコントローラを取得しcharacterControllerを実体化
        characterController = GetComponent<CharacterController>();
        //アニメーターを取得し以下略
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクタコントローラが設置している場合に処理（のちにジャンプを追加する場合に分岐）
        if(characterController.isGrounded)
        {
            //x軸を上下キーから、z軸を左右キーから取得?
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            //アニメーターのForwardSpeedにz軸の値を代入（縦軸移動）
            animator.SetFloat("ForwardSpeed", Input.GetAxis("Vertical"));
            //LateralSpeedにx軸の値を代入（横軸移動）
            animator.SetFloat("LateralSpeed", Input.GetAxis("Horizontal"));
            //キャラクタコントローラから移動命令、上下左右キーで方向、入力される間
            characterController.Move(velocity * walkSpeed * Time.deltaTime);

        }

        //走る方向に体を向けたい
        //カメラの向きを基準に移動する方向を決定したほうがいい？

        //移動したい方向が0.01より大きい場合（方向転換するときは常に条件を満たす）
        if (velocity.magnitude > 0.01f)
        {
            Quaternion q = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, derSpeed * Time.deltaTime);

        }
    }
}
