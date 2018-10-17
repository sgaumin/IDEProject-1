﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        public enum gameStates {Playing, Dialogue, Pause, End};
        public gameStates gameState = gameStates.Playing;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else if (instance != null)
            {
                Destroy(this);
            }
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ReloagScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }

