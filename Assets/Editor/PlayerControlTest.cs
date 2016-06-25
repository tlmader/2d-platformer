using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PlayerControlTest {

    [Test]
    public void Update_JumpWhileGrounded()
    {
        var found = GameObject.FindGameObjectWithTag("Player");
		var expected = "TestCharacter";
		var actual = found.name;

        Assert.AreEqual(expected, actual);
    }
}
