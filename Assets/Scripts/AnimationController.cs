using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //宣言
    private Animator animator;
    CharacterController controller;
    Vector3 moveDirection;
    public PlayerController playerController;

    //inspectorで変更可能にする:移動速度と回転速度
    [SerializeField] private float fSpeed = 3.0f;
    [SerializeField]private float derSpeed = 360;

    // Start is called before the first frame update
    void Start()
    {
        //キャラクタコントローラを取得しcharacterControllerを実体化
        controller = GetComponent<CharacterController>();
        //アニメーターを取得し以下略
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.attackBool == false)
        {
            controller.Move(moveDirection * Time.deltaTime);

            //カメラの向きを基準に正面を取得
            Vector3 forward = Camera.main.gameObject.transform.TransformDirection(Vector3.forward);
            //カメラの側面を基準に横軸を取得
            Vector3 right = Camera.main.gameObject.transform.TransformDirection(Vector3.right);
            //上で取得した値を力のかかる向きにする　horizontalはx軸、verticalはz軸の力
            moveDirection = Input.GetAxis("Horizontal") * right + Input.GetAxis("Vertical") * forward;
            moveDirection *= fSpeed;

            //アニメーターのForwardSpeedにz軸の値を代入（縦移動のアニメーションを再生する条件）
            animator.SetFloat("ForwardSpeed", Input.GetAxis("Vertical"));
            //LateralSpeedにx軸の値を代入（横移動のアニメーション）
            animator.SetFloat("LateralSpeed", Input.GetAxis("Horizontal"));

            //移動したい方向が0.01より大きい場合（方向転換するときは常に条件を満たす）
            if (moveDirection.magnitude > 0.01f)
            {
                Quaternion q = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, derSpeed * Time.deltaTime);
            }            
        }        
    }
}
