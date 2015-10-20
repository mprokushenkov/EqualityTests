﻿using System;
using System.Reflection;
using EqualityTests.Exception;
using Ploeh.AutoFixture.Idioms;

namespace EqualityTests
{
    public class EqualityOperatorOverloadAssertion : IdiomaticAssertion
    {
        public override void Verify(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var equalityOperatorOverload =
                type.GetMethod("op_Equality", new[] {type, type});

            if (equalityOperatorOverload == null)
            {
                throw new EqualityOperatorException(
                    string.Format("Expected type {0} to overload == operator with parameters of type {0}", type.Name));
            }
        }
    }
}
