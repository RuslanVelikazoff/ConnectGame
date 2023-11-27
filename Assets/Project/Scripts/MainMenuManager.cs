using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Connect.Core
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Instance;

        [SerializeField] private GameObject _titlePanel;
        [SerializeField] private GameObject _stagePanel;
        [SerializeField] private GameObject _levelPanel;

        [SerializeField] private Image musicButton;
        [SerializeField] private Sprite musicOnSprite;
        [SerializeField] private Sprite musicOffSprite;

        [SerializeField] private Image soundButton;
        [SerializeField] private Sprite soundOnSprite;
        [SerializeField] private Sprite soundOffSprite;

        private void Awake()
        {
            Instance = this;

            SetSprites();

            _titlePanel.SetActive(true);
            _stagePanel.SetActive(false);
            _levelPanel.SetActive(false);
        }

        public void ClickedPlay()
        {
            _titlePanel.SetActive(false);
            _stagePanel.SetActive(true);
        }

        public void ClickedBackToTitle()
        {
            _titlePanel.SetActive(true);
            _stagePanel.SetActive(false);
        }

        public void ClickedBackToStage()
        {
            _stagePanel.SetActive(true);
            _levelPanel.SetActive(false);
        }

        public void Music()
        {
            if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
            {
                AudioManager.instance.OffMusic();
            }
            else
            {
                AudioManager.instance.OnMusic();
            }
            SetSprites();
        }

        public void Sound()
        {
            if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
            {
                AudioManager.instance.OffSound();
            }
            else
            {
                AudioManager.instance.OnSound();
            }
            SetSprites();
        }

        private void SetSprites()
        {
            if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
            {
                musicButton.sprite = musicOnSprite;
            }
            else
            {
                musicButton.sprite = musicOffSprite;
            }

            if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
            {
                soundButton.sprite = soundOnSprite;
            }
            else
            {
                soundButton.sprite = soundOffSprite;
            }
        }

        public UnityAction LevelOpened;

        [HideInInspector]
        public Color CurrentColor;

        [SerializeField]
        private TMP_Text _levelTitleText;
        [SerializeField]
        private Image _levelTitleImage;

        public void ClickedStage(string stageName, Color stageColor)
        {
            _stagePanel.SetActive(false);
            _levelPanel.SetActive(true);
            CurrentColor = stageColor;
            _levelTitleText.text = stageName;
            _levelTitleImage.color = CurrentColor;
            LevelOpened?.Invoke();
        }
    } 
}

