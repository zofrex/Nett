﻿using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace Nett.Coma.Tests.Unit
{
    [ExcludeFromCodeCoverage]
    public sealed class ComaConfigTests
    {
        [Fact(DisplayName = "Load with null as file locations throws argument null exception.")]
        public void LoadMergedConfig_WhenLocationsIsNull_ThrowsArgNull()
        {
            // Act
            Action a = () => Config.Create(() => new SingleLevelConfig(), (string)null);

            // Assert
            a.ShouldThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Load with only one file location causes argument exception.")]
        public void LoadMergedConfig_WhenOnlyOneLocationProvided_ThrowsArg()
        {
            // Act
            Action a = () => Config.Create<SingleLevelConfig>(null, "oneFileOnly");

            // Assert
            a.ShouldThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Load with null as default creator throws argument null exception.")]
        public void LoadMergedConfig_WhenDefaultCreatorIsNull_ThrowsArgNull()
        {
            // Act
            Action a = () => Config.Create<SingleLevelConfig>(null, "x", "y");

            // Assert
            a.ShouldThrow<ArgumentNullException>();
        }
    }
}
