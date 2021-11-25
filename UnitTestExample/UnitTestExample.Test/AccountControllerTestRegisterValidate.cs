﻿using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestRegisterValidate
    {
        [
        Test,
        TestCase("irf@uni-corvinus", "Abcd1234"),
        TestCase("irf.uni-corvinus.hu", "Abcd1234"),
        TestCase("irf@uni-corvinus.hu", "abcd1234"),
        TestCase("irf@uni-corvinus.hu", "ABCD1234"),
        TestCase("irf@uni-corvinus.hu", "abcdABCD"),
        TestCase("irf@uni-corvinus.hu", "Ab1234"),
        ]
        public void TestRegisterValidateException(string email, string password)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }

            // Assert
        }
    }
}
