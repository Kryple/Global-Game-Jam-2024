using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ChangeSceneButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressedClip, _uncompressedClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool _isChangeSceneButton = true;
    
    [SerializeField] float _transitionTime = .44f;
    string a_StartCrossfade = "StartCrossfade";

    RectTransform _rectTransform;
    [SerializeField] int _sceneId;
    float _changeY = 5.6f;

    private void Start() 
    {
        _image = GetComponent<Image>();
        if (_image == null)
            Debug.LogWarning("_image is null");

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("_audioSource is null");

        _rectTransform = GetComponent<RectTransform>();
        if (_rectTransform == null)
        {
            Debug.LogWarning("_rectTransform is null");
        }
    }
    
    //OnPointerUp is called after: Release after Click, Drag Release, Cancel Drag
    public void OnPointerUp(PointerEventData eventData)
    {
        
        _image.sprite = _default;
        // _audioSource.volume = 0.23f;
        // _audioSource.pitch = 0.23f;
        // _audioSource.PlayOneShot(_uncompressedClip);
        
        if (_isChangeSceneButton == true)
            StartCoroutine(LoadLevel(_sceneId));

        Vector2 anchoredPosition = _rectTransform.anchoredPosition;

        // Modify the Y component to the new value
        anchoredPosition.y += _changeY;

        // Assign the modified anchored position back to the RectTransform
        _rectTransform.anchoredPosition = anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 1;
        _image.sprite = _pressed;
        _audioSource.volume = 0.8f;
        _audioSource.pitch = 1f;
        
        _audioSource.PlayOneShot(_compressedClip);
        Vector2 anchoredPosition = _rectTransform.anchoredPosition;

        // Modify the Y component to the new value
        anchoredPosition.y -= _changeY;

        // Assign the modified anchored position back to the RectTransform
        _rectTransform.anchoredPosition = anchoredPosition;
        
        
    }
    
    IEnumerator LoadLevel(int _sceneId)
    {
        // _transition.SetTrigger(a_StartCrossfade);
        yield return new WaitForSeconds(_transitionTime);
        
        //LoadSceneMode.Single: unload the current scene before loading the new one.
        SceneManager.LoadScene(_sceneId, LoadSceneMode.Single);
        
    }
}

