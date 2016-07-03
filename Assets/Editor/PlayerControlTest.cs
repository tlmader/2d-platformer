using NUnit.Framework;
using UnityEditor;
using UnityEngine;

[TestFixture]
public class PlayerControlTest {

	private GameObject go;
	private PlayerControl playerControl;

	[SetUp]
	protected void SetUp()
	{
		go = new GameObject();
		go.AddComponent<Rigidbody2D>();
		playerControl = go.AddComponent<PlayerControl>();
		playerControl.Start();
	}

    [Test]
	public void GetHorizontalForce_WithPositiveXAxis_ReturnsVectorWithPositiveX()
	{
		playerControl.grounded = true;
		playerControl.speed = 50f;

		var expected = Vector2.right * 50f;
		var actual = playerControl.GetHorizontalForce(1f);

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetHorizontalForce_WithNegativeXAxis_ReturnsVectorWithNegativeX()
	{
		playerControl.grounded = true;
		playerControl.speed = 50f;

		var expected = -Vector2.right * 50f;
		var actual = playerControl.GetHorizontalForce(-1f);

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetHorizontalForce_WithSameDirectionWhileNotGrounded_ReturnsVector2WithChanges()
	{
		playerControl.grounded = false;
		playerControl.speed = 50f;

		var expected = Vector2.right * 50f;
		var actual = playerControl.GetHorizontalForce(1f);

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetHorizontalForce_WithDifferentDirectionWhileNotGrounded_ReturnsVector2ForCurrentVelocity()
	{
		playerControl.transform.localScale = new Vector3(-1, 1, 1);
		playerControl.grounded = false;
		playerControl.speed = -50f;

		var expected = playerControl.GetBody().velocity;
		var actual = playerControl.GetHorizontalForce(1f);

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetCappedVelocity_WhileVelocityXGreaterThanMaxSpeed_ReturnsNewVector2WithXAsMaxSpeed()
	{
		playerControl.maxSpeed = 3f;
		var body = playerControl.GetBody();
		body.velocity = new Vector2(4f, body.velocity.y);

		var expected = new Vector2(playerControl.maxSpeed, body.velocity.y);
		var actual = playerControl.GetCappedVelocity();

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetJumpForce_WithPositiveJumpPower_ReturnsCorrectVector2()
	{
		playerControl.jumpPower = 300f;

		var expected = Vector2.up * 300f;
		var actual = playerControl.GetJumpForce();

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetCappedVelocity_WhileVelocityXLessThanNegativeMaxSpeed_ReturnsNewVector2WithXAsNegativeMaxSpeed()
	{
		playerControl.maxSpeed = 3f;
		var body = playerControl.GetBody();
		body.velocity = new Vector2(-4f, body.velocity.y);

		var expected = new Vector2(-playerControl.maxSpeed, body.velocity.y);
		var actual = playerControl.GetCappedVelocity();

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetDirection_WithPositiveXAxis_ReturnsVector3WithPositiveX()
	{
		playerControl.grounded = true;
		var expected = new Vector3(1, 1, 1);
		var actual = playerControl.GetDirection(1f);

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetDirection_WithNegativeXAxis_ReturnsVector3WithNegativeX()
	{
		playerControl.grounded = true;
		var expected = new Vector3(-1, 1, 1);
		var actual = playerControl.GetDirection(-1f);

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetDirection_WithDifferentDirectionWhileNotGrounded_ReturnsVector3ForCurrentLocalScale()
	{
		playerControl.grounded = false;
		var expected = new Vector3(1, 1, 1);
		var actual = playerControl.GetDirection(-1f);

		Assert.AreEqual(expected, actual);
	}
}
