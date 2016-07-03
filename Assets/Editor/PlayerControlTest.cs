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
    public void FirstTest()
    {
        var found = GameObject.FindGameObjectWithTag("Player");
		var expected = "TestCharacter";
		var actual = found.name;

        Assert.AreEqual(expected, actual);
    }

	[Test]
	public void GetCappedVelocity_VelocityXIsGreaterThanMaxSpeed_VelocityEqualsNewVectorWithXAsMaxSpeed()
	{
		playerControl.maxSpeed = 3f;
		var body = playerControl.GetBody();
		body.velocity = new Vector2(4f, body.velocity.y);

		var expected = new Vector2(playerControl.maxSpeed, body.velocity.y);
		var actual = playerControl.GetCappedVelocity();

		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void GetCappedVelocity_VelocityXIsLessThanNegativeMaxSpeed_VelocityEqualsNewVectorWithXAsNegativeMaxSpeed()
	{
		playerControl.maxSpeed = 3f;
		var body = playerControl.GetBody();
		body.velocity = new Vector2(-4f, body.velocity.y);

		var expected = new Vector2(-playerControl.maxSpeed, body.velocity.y);
		var actual = playerControl.GetCappedVelocity();

		Assert.AreEqual(expected, actual);
	}
}
