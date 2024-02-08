using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace ZeroProject.Level
{
    public class LevelConstructor
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly LevelRoot _levelRoot;
        private readonly IInstantiator _instantiator;
        private readonly List<GameObject> _instRooms = new List<GameObject>();
        
        private List<Room.Room> _roomViews = new List<Room.Room>();

        public LevelConstructor(
            LevelGenerator levelGenerator,
            LevelRoot levelRoot,
            IInstantiator instantiator)
        {
            _levelGenerator = levelGenerator;
            _levelRoot = levelRoot;
            _instantiator = instantiator;
        }

        public void SetupLevel()
        {
            _roomViews = _levelGenerator.GenerateLevel();

            for (int i = 0; i < _roomViews.Count; i++)
            {
                if (i == 0)
                {
                    Init(_roomViews[0], _levelRoot.PoolContainer);
                    break;
                }

                if (i == _roomViews.Count - 1)
                {
                    Init(_roomViews[_roomViews.Count - 1], _levelRoot.PoolContainer);
                    break;
                }
                
                var index = Random.Range(1, _roomViews.Count - 1);
                Init(_roomViews[index], _levelRoot.PoolContainer);
            }
        }
        
        public void ShowFirstRoom()
        {
            _instRooms[0].transform.SetParent(_levelRoot.Container);
        }

        private void Init(Room.Room prefab, Transform parent = null)
        {
            GameObject instRoom;
            if (parent == null)
            {
                instRoom = _instantiator.InstantiatePrefab(prefab);
            }
            else
            {
                instRoom = _instantiator.InstantiatePrefab(prefab, parent);
            }
            
            _instRooms.Add(instRoom);
        }

        
    }
}