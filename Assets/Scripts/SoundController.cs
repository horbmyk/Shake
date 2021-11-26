using UnityEngine;

namespace Shake
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _soundFood;

        public void PlaySoundFood()
        {
            _soundFood.Play();
        }
    }
}
