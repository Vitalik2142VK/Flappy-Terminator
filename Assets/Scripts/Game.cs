using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StartButton _startGame;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Ground _ground;

    private void OnEnable()
    {
        _startGame.GameStrat += StartGame;
        _player.GameOver += OverGame;
    }

    private void OnDisable()
    {
        _startGame.GameStrat -= StartGame;
        _player.GameOver -= OverGame;
    }

    private void StartGame()
    {
        _startGame.Close();
        _player.Activation();
        _enemySpawner.gameObject.SetActive(true);
        _ground.Move();
    }

    private void OverGame()
    {
        _ground.Stop();
        _startGame.Open();
        _enemySpawner.RemoveAll();
        _enemySpawner.gameObject.SetActive(false);
    }
}
