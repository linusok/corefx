﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization.Policies;

namespace System.Text.Json.Serialization.Converters
{
    internal sealed class JsonValueConverterDecimalNullable : JsonValueConverter<decimal?>
    {
        public override bool TryRead(Type valueType, ref Utf8JsonReader reader, out decimal? value)
        {
            if (reader.TokenType != JsonTokenType.Number
                || !reader.TryGetDecimal(out decimal rawValue))
            {
                value = default;
                return false;
            }

            value = rawValue;
            return true;
        }

        public override void Write(decimal? value, ref Utf8JsonWriter writer)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override void Write(Span<byte> escapedPropertyName, decimal? value, ref Utf8JsonWriter writer)
        {
            writer.WriteNumber(escapedPropertyName, value.Value);
        }
    }
}
