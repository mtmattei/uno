﻿using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Storage;

namespace Uno.UI.Tests.Windows_Storage;

[TestClass]
public class Given_DataTypeSerializer
{
	[TestMethod]
	public void When_Null_Deserialize()
	{
		// Arrange
		string value = null;

		// Act
		var result = DataTypeSerializer.Deserialize(value);

		// Assert
		Assert.IsNull(result);
	}

	[TestMethod]
	public void When_Valid_Deserialize()
	{
		// Arrange
		string value = "System.Int32:42";

		// Act
		var result = DataTypeSerializer.Deserialize(value);

		// Assert
		Assert.AreEqual(42, result);
	}

	[TestMethod]
	public void When_Deserialize_Then_ReturnNull()
	{
		// Arrange
		string value = "System.Int32";

		// Act
		var result = DataTypeSerializer.Deserialize(value);

		// Assert
		Assert.IsNull(result);
	}

	[TestMethod]
	public void When_Invalid_Value_Valid_Type_Deserialize()
	{
		// Arrange
		string value = "System.Int32:invalid";

		// Act & Assert
		Assert.ThrowsException<FormatException>(() => DataTypeSerializer.Deserialize(value));
	}

	[TestMethod]
	public void When_Value_No_Separator()
	{
		// Arrange
		string value = "I don't contain the separator";

		// Act
		var result = DataTypeSerializer.Deserialize(value);

		// Assert
		Assert.IsNull(result);
	}

	[TestMethod]
	public void When_DateTimeOffset_Deserialize()
	{
		// Arrange
		string value = "System.DateTimeOffset:2022-01-01T00:00:00+00:00";

		// Act
		var result = DataTypeSerializer.Deserialize(value);

		// Assert
		Assert.AreEqual(new DateTimeOffset(2022, 1, 1, 0, 0, 0, TimeSpan.Zero), result);
	}

	[TestMethod]
	public void When_Guid_Deserialize()
	{
		// Arrange
		string value = "System.Guid:123e4567-e89b-12d3-a456-426655440000";

		// Act
		var result = DataTypeSerializer.Deserialize(value);

		// Assert
		Assert.AreEqual(new Guid("123e4567-e89b-12d3-a456-426655440000"), result);
	}

	[TestMethod]
	public void When_TimeSpan_Deserialize()
	{
		// Arrange
		string value = "System.TimeSpan:00:01:00";

		// Act
		var result = DataTypeSerializer.Deserialize(value);

		// Assert
		Assert.AreEqual(TimeSpan.FromMinutes(1), result);
	}

	[TestMethod]
	public void When_Null_Serialize()
	{
		// Arrange
		object value = null;

		// Act & Assert
		Assert.ThrowsException<ArgumentNullException>(() => DataTypeSerializer.Serialize(value));
	}

	[TestMethod]
	public void When_Unsupported_Type_Serialize()
	{
		// Arrange
		object value = new StringBuilder();

		// Act & Assert
		Assert.ThrowsException<NotSupportedException>(() => DataTypeSerializer.Serialize(value));
	}

	[TestMethod]
	public void When_Supported_Type_Serialize()
	{
		// Arrange
		object value = 42;

		// Act
		var result = DataTypeSerializer.Serialize(value);

		// Assert
		Assert.AreEqual("System.Int32:42", result);
	}
}
