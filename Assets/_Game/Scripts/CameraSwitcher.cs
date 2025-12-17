using Cinemachine;
using UnityEngine;

namespace _Game.Scripts
{
    public class CameraSwitcher : MonoBehaviour
    {
        private const int StepIndex = 1;
        
        [SerializeField] private CinemachineVirtualCamera[] _virtualCameras;
        
        private int _currentCameraIndex;
        private IInput _input;

        public void Initialize(IInput input)
        {
            _input = input;
        }

        private void Update()
        {
            if (_input.SwitchCamera)
            {
                Switch();
            }
        }

        private void Switch()
        {
            Debug.Log("Switch" + _currentCameraIndex);
            
            _currentCameraIndex += StepIndex;

            if (_currentCameraIndex >= _virtualCameras.Length)
                _currentCameraIndex = 0;
            
            foreach (CinemachineVirtualCamera virtualCamera in _virtualCameras)
            {
                virtualCamera.enabled = false;
            }
            
            _virtualCameras[_currentCameraIndex].enabled = true;
        }
    }
}