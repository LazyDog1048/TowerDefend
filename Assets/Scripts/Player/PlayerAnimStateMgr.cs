﻿using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Player
{
    public  class PlayerAnimStateMgr : MonoBehaviour
    {
        public static PlayerAnimStateMgr Instance;
        static private PlayerState _playerState;
        private PlayerState _lastState;
        private Animator _anim;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        
        
        void Start()
        {
            Instance = this;
            _anim = GetComponent<Animator>();
        }

        public static void SetFaceDir(float faceDir)
        {
            Instance._anim.SetFloat("faceDir", faceDir);
        }
        
        public static void TryChangeState(PlayerState playerState)
        {
            if(playerState == _playerState)
                return;
            
            switch (playerState)
            {
                case PlayerState.Idle:
                        _playerState = playerState;
                    break;
                case PlayerState.Walk:
                        _playerState = playerState;
                    break;
            }
            
            Instance.OnPlayerStateChange(_playerState);
        }
        
        
        void OnPlayerStateChange(PlayerState playerState)
        {
            if(playerState == _lastState)
                return;
            _lastState = playerState;
            
            StateResume();
            
            switch (playerState)
            {
                case PlayerState.Walk:
                    _anim.SetBool("isWalk", true);
                    break;
                
                
                    
            }
        }
        //重置所有状态
        void StateResume()
        {
            _anim.SetBool("isWalk", false );
        }

        public static PlayerState CurState()
        {
            return _playerState;
        }
    }
}
