using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;

namespace FireAndWater.Level
{
    public class LevelManage : MonoBehaviour
    {
        [SerializeField, Scene] private int _scene;
        [SerializeField] private List<Door> _doors = new List<Door>();

        private List<bool> _active = new List<bool>();

        private void Start()
        {
            for (int i = 0; i < _doors.Count; i++)
            {
                int index=i;
                _active.Add(false);
                _doors[i].OnInside += () => Inside(index);
                _doors[i].OnOutside += () => Outside(index);
            }
        }

        private void Inside(int index)
        {
            _active[index] = true;
            TryTrasition();
        }

        private void Outside(int index)
        {
            _active[index] = false;
        }

        private void TryTrasition()
        {
            foreach (bool active in _active)
            {
                if (active == false) return;
            }
            SceneManager.LoadScene(_scene);
        }
    }
}