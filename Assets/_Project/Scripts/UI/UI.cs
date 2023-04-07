using System;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class UI : MonoBehaviour
    {
        public bool _inMenu = true;

        private void Awake()
        {
            SetActivePlayerState(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void SetActivePlayerState(bool value)
        {
            _inMenu = !value;
        }
    }
}