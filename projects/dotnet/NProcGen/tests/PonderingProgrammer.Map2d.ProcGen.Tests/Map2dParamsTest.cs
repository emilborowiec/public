using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace PonderingProgrammer.Map2d.ProcGen.Tests
{
    public class Map2dParamsTest
    {
        [Fact]
        public void TestValidation()
        {
            var options = new Map2dParams { Width = 3, Height = 3, DesiredCellCount = 5 };
            var context = new ValidationContext(options);
            var validationResults = new List<ValidationResult>();
            Assert.True(Validator.TryValidateObject(options, context, validationResults));
            
            options = new Map2dParams { Width = 1, Height = 0, DesiredCellCount = 10 };
            context = new ValidationContext(options);
            Assert.False(Validator.TryValidateObject(options, context, validationResults));
            Assert.Equal(3, validationResults.Count);
        }
    }
}
