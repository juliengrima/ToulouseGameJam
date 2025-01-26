using UnityEngine;
using UnityEngine.UI;

namespace mynamespace
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] Slider _volume;
        
        void Start()
        {
           if(!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 1);
                Load();
            }
           else
            {
                Load();
            }
        }
        
        public void ChangeVolume()
        {
            AudioListener.volume = _volume.value;
            Save();
        }

        private void Load()
        {
            _volume.value = PlayerPrefs.GetFloat("musicVolume");
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("musicVolume", _volume.value);
        }
    }
}
