using Code.Gameplay.Input;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Hero
{
	public class HeroMover : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed = 5f;
		[SerializeField] private float _rotationSpeed = 700f;
		[SerializeField] private float _gravity = -9.81f;
		[SerializeField] private CharacterController _characterController;

		private Vector2 _movementInput;

		private IInputService _inputService;

		private Vector3 velocity;

		[Inject]
		public void Constructor(IInputService inputService) => 
			_inputService = inputService;

		private void Update()
		{
			_movementInput = new Vector2(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis());

			Move();
		}

		private void Move()
		{
			Vector3 moveDirection = new Vector3(_movementInput.x, 0f, _movementInput.y).normalized;

			if (moveDirection.magnitude >= 0.1f)
			{
				float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
				float currentAngle = transform.eulerAngles.y;

				float angle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * _rotationSpeed);
				transform.rotation = Quaternion.Euler(0, angle, 0);

				Vector3 move = transform.forward * _moveSpeed * Time.deltaTime;
				_characterController.Move(move);
			}

			if (_characterController.isGrounded)
				velocity.y = -2f;
			else
				velocity.y += _gravity * Time.deltaTime;

			_characterController.Move(velocity * Time.deltaTime);
		}
	}
}