using UnityEngine;

[RequireComponent(typeof(Bag))]
[RequireComponent(typeof(AudioSource))]
public class InteractDetector : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _coinSound;

    private Bag _bag;

    private void Start()
    {
        _bag = GetComponent<Bag>();
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _coinSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _bag.AddCoin();
            _audioSource.Play();
            Destroy(collision.gameObject);
        }
    }
}
