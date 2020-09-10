using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 prevPlayerPos;
    private Vector3 posVector;
    public float scale = 3.0f;
    public float cameraSpeed = 1.0f;

    void Start()
    {
        player = GameObject.Find("Ekard");
        //後ろ-1z
        prevPlayerPos = new Vector3(0, 0, -1);
    }

    void Update()
    {
        //現在のプレイヤー位置を取得
        Vector3 currentPlayerPos = player.transform.position;
        //現在のプレイヤー位置の後ろを基準に設定（magnitude=1）
        Vector3 backVector = (prevPlayerPos - currentPlayerPos).normalized;

        //posVector = (backVector == Vector3.zero) ? posVector : backVector;
        //Vector3 targetPos = currentPlayerPos + scale * posVector;
        //targetPos.y = targetPos.y + 0.5f;

        //this.transform.position = Vector3.Lerp(this.transform.position,targetPos,cameraSpeed * Time.deltaTime);

        this.transform.LookAt(player.transform.position);

        prevPlayerPos = player.transform.position;

    }
}
