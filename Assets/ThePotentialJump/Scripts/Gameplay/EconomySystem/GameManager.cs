﻿using ThePotentialJump.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThePotentialJump.Gameplay
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private GameType gameType;
        [SerializeField] private string nextLevel;
        [SerializeField] private SceneFadeInOut sceneFadeInOut;


        public GameType GameType { get => gameType; }

        protected override void Awake()
        {
            destroyOnLoad = true;
            base.Awake();
        }

        public void LoadNextLevel()
        {
            sceneFadeInOut.FadeOut(0.0f, nextLevel);
        }

        public void Restart()
        {
            sceneFadeInOut.FadeOut(0.0f, SceneManager.GetActiveScene().name);
        }

        public void GoToMainMenu()
        {
            sceneFadeInOut.FadeOut(0.0f, "MainMenu");
        }


        [SerializeField] private bool restart;
        [SerializeField] private bool goMainMenu;
        [SerializeField] private bool loadNextLevel;
        private void Update()
        {
            if (restart)
            {
                Restart();
                restart = false;
            }
            if (goMainMenu)
            {
                GoToMainMenu();
                goMainMenu = false;
            }
            if (loadNextLevel)
            {
                LoadNextLevel();
                loadNextLevel = false;
            }
        }
    }

}