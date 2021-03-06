﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    Rigidbody rigidbody;
    public GameObject[] followers;
    public float velocity = 3.0f;
    int followerIndex = 1;

    void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        //settings 값 초기화
    }

	void Start () {
        
	}

    public void Init(GameObject[] followers) 
    {
        this.followers = followers;
    }

    void Update () {
        // this.rigidbody.AddForce(this.transform.forward * 200
        //     , ForceMode.VelocityChange);
        var targetPosition = followers[followerIndex].transform.position; // 이동할 곳의 포지션
        var look = targetPosition - this.transform.position;
        targetPosition.y = 0;
        var currentPostion = this.transform.position;
        currentPostion.y = 0;
        look.y = 0;
        this.transform.forward = look.normalized; // 이동할 곳을 보는 벡터로 forward 지정

        if(Vector3.Distance(currentPostion, targetPosition) < 0.1f) // 0.1f 이내로 오면 다음 녀석으로 이동
        {
            followerIndex++;
            if(followerIndex == followers.Length) // 마지막에 오면 지우겠다
            {
                CharacterManager.Instance.removeEnemy(this.gameObject); //리스트에서 빼기 위함
                Destroy(this.gameObject.GetComponent<CharacterMovement>());
                this.gameObject.SetActive(false);
                followerIndex = 1;
            }   
        }
        // this.transform.position = this.transform.position + transform.forward * velocity * Time.deltaTime;
        this.rigidbody.AddForce(this.transform.forward * 50, ForceMode.Acceleration);
    }
}
