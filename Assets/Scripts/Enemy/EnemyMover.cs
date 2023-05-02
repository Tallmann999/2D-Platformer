using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _startPoints;
    [SerializeField] private Transform _endPoints;
    [SerializeField] private float _speedMove = 2f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _moveLeft = true;
    //[SerializeField] private Rigidbody2D _rigidbody;
    private void Start()
    {
        //_rigidbody = GetComponent<Rigidbody2D>();
        //StartCoroutine(MovingAndWait());
        _spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.transform.position = new Vector3(_startPoints.position.x, _startPoints.position.y, _startPoints.position.z);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPoints.position, _speedMove*Time.deltaTime);

        if (transform.position ==_endPoints.position)
        {
            //transform.eulerAngles = new Vector3(0,180,0);
            _spriteRenderer.flipX = true;
            Transform nextStep = _startPoints;
            _startPoints = _endPoints;
            _endPoints = nextStep;
            // не работает поворот в другую сторону
        }
    }

    //private IEnumerator MovingAndWait()
    //{
    //    int iteration = 10;

    //    while (true)
    //    {
    //        transform.position = _points[0].position;
    //        yield return new WaitForSeconds(5f);
    //        transform.position = _points[1].position;
    //        iteration--;
    //    }
    //}
}
