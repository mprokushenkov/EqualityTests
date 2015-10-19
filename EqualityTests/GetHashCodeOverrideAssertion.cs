﻿using System;
using EqualityTests.Extensions;
using Ploeh.AutoFixture.Idioms;

namespace EqualityTests
{
    public class GetHashCodeOverrideAssertion : IdiomaticAssertion
    {
        public override void Verify(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var getHashCodeMethod = type.GetMethod("GetHashCode");

            if (getHashCodeMethod.IsObjectGetHashCodeMethod())
            {
                throw new GetHashCodeOverrideException(string.Format(
                    "Expected type {0} to override GetHashCode method", type.Name));
            }
        }
    }
}
