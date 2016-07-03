using NUnit.Framework;
using UnityEditor;
using UnityEngine;

[TestFixture]
public class PlayerControlTest {

	private GameObject testObject;
	private PlayerControl playerControl;

	[SetUp]
	protected void SetUp()
	{
		testObject = new GameObject();
		playerControl = testObject.AddComponent<PlayerControl>();
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
	public void SetVelocityToMaxSpeed_VelocityXIsGreaterThanMaxSpeed_VelocityEqualsNewVectorWithXAsMaxSpeed()
	{

		playerControl.maxSpeed = 3f;
		var body = playerControl.GetBody();
		body.velocity = new Vector2(4f, body.velocity.x);
		var expected = new Vector2(playerControl.maxSpeed, body.velocity.y);
		var actual = playerControl.SetVelocityToMaxSpeed();
		Assert.AreEqual(expected, actual);
	}

	[Test]
	public void SetVelocityToMaxSpeed_VelocityXIsLessThanNegativeMaxSpeed_VelocityEqualsNewVectorWithXAsNegativeMaxSpeed()
	{
		playerControl.maxSpeed = 3f;
		var body = playerControl.GetBody();
		body.velocity = new Vector2(-4f, body.velocity.x);
		var expected = new Vector2(-playerControl.maxSpeed, body.velocity.y);
		var actual = playerControl.SetVelocityToMaxSpeed();
		Assert.AreEqual(expected, actual);
	}
}
