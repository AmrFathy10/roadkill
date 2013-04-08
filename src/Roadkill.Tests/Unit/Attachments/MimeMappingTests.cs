﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roadkill.Core.Attachments;

namespace Roadkill.Tests.Unit.Attachments
{
	[TestFixture]
	public class MimeMappingTests
	{
		[Test]
		public void Should_Return_Application_MimeType_For_Empty_Extension()
		{
			// Arrange
			string expected = "application/octet-stream";

			// Act
			string actual = MimeMapping.GetMimeMapping("");

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void Should_Return_Application_MimeType_For_Unknown_Extension()
		{
			// Arrange
			string expected = "application/octet-stream";

			// Act
			string actual = MimeMapping.GetMimeMapping(".blah");

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void Should_Ignore_Case_For_Extension()
		{
			// Arrange
			string expected = "image/jpeg";

			// Act
			string actual = MimeMapping.GetMimeMapping(".JPEG");

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("image/jpeg",".jpg")]
		[TestCase("image/png", ".png")]
		[TestCase("image/gif", ".gif")]
		[TestCase("application/x-shockwave-flash", ".swf")]
		[TestCase("application/pdf", ".pdf")]
		public void Should_Return_Known_Types_Common_Extension(string expectedMimeType, string extension)
		{
			// Arrange

			// Act
			string actual = MimeMapping.GetMimeMapping(extension);

			// Assert
			Assert.That(actual, Is.EqualTo(expectedMimeType));
		}
	}
}
