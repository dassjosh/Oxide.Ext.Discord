using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Formatting Helpers for Placeholders
    /// </summary>
    internal static class PlaceholderFormatting
    {
        private static readonly Regex GenericPositionRegex = new(@"([xyz])(?::?([\d\.]*))", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Replace the <see cref="PlaceholderState"/> with the string value
        /// </summary>
        /// <param name="builder"><see cref="StringBuilder"/> for the placeholder</param>
        /// <param name="state"><see cref="PlaceholderState"/> for the placeholder</param>
        /// <param name="value">Placeholder value to replace</param>
        private static void Replace(StringBuilder builder, PlaceholderState state, ReadOnlySpan<char> value)
        {
            builder.Replace(value, state.Index, state.Length);
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, IReadOnlyList<string> values)
        {
            builder.Remove(state.Index, state.Length);
            if (values == null || values.Count == 0)
            {
                return;
            }

            string separator = !string.IsNullOrEmpty(state.Format) ? state.Format : ", ";
            for (int index = 0; index < values.Count; index++)
            {
                if (index != 0)
                {
                    builder.Append(separator);
                }
                builder.Append(values[index]);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, IReadOnlyList<object> values)
        {
            builder.Remove(state.Index, state.Length);
            if (values == null || values.Count == 0)
            {
                return;
            }

            string separator = !string.IsNullOrEmpty(state.Format) ? state.Format : ", ";
            for (int index = 0; index < values.Count; index++)
            {
                if (index != 0)
                {
                    builder.Append(separator);
                }
                builder.Append(values[index]);
            }
        }

        /// <summary>
        /// Replace the <see cref="Match"/> with the the string value
        /// </summary>
        /// <param name="builder"><see cref="StringBuilder"/> for the placeholder</param>
        /// <param name="state"><see cref="Match"/> for the placeholder</param>
        /// <param name="value">Snowflake value to replace</param>
        private static void Replace(StringBuilder builder, PlaceholderState state, bool value)
        {
            if (string.IsNullOrEmpty(state.Format))
            {
                Replace(builder, state, value ? "true" : "false");
                return;
            }

            int split = state.Format.IndexOf(',');
            if (split == -1)
            {
                Replace(builder, state, value ? "true" : "false");
                return;
            }

            ReadOnlySpan<char> span = state.Format;
            if (value)
            {
                span = span.Slice(0, split);
            }
            else
            {
                span = span.Slice(split + 1, span.Length - split - 1);
            }

            Replace(builder, state, span);
        }

        /// <summary>
        /// Replace the <see cref="Match"/> with the the <see cref="Snowflake"/> value
        /// </summary>
        /// <param name="builder"><see cref="StringBuilder"/> for the placeholder</param>
        /// <param name="state"><see cref="Match"/> for the placeholder</param>
        /// <param name="value">Snowflake value to replace</param>
        private static void Replace(StringBuilder builder, PlaceholderState state, Snowflake value)
        {
            Replace(builder, state, value.Id);
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, byte value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, sbyte value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, short value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, ushort value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, int value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, uint value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, long value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, ulong value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, float value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, double value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, decimal value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, DateTime value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, DateTimeOffset value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        private static void Replace(StringBuilder builder, PlaceholderState state, TimeSpan value)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, state.Format))
            {
                Replace(builder, state, span);
            }
            else
            {
                Replace(builder, state, value as IFormattable);
            }
        }

        /// <summary>
        /// Replace the <see cref="Match"/> with the the string value
        /// </summary>
        /// <param name="builder"><see cref="StringBuilder"/> for the placeholder</param>
        /// <param name="state"><see cref="Match"/> for the placeholder</param>
        /// <param name="value"><see cref="IFormattable"/> value to use with formatting</param>
        private static void Replace(StringBuilder builder, PlaceholderState state, IFormattable value)
        {
            if (string.IsNullOrEmpty(state.Format))
            {
                Replace(builder, state, value.ToString(null, CultureInfo.CurrentCulture));
                return;
            }

            Replace(builder, state, value.ToString(state.Format, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Replace the <see cref="PlaceholderState"/> with the formatted position
        /// </summary>
        /// <param name="builder"><see cref="StringBuilder"/> for the placeholder</param>
        /// <param name="placeholderState"><see cref="PlaceholderState"/> for the placeholder</param>
        /// <param name="position"><see cref="GenericPosition"/> position to format and replace</param>
        private static void Replace(StringBuilder builder, PlaceholderState placeholderState, GenericPosition position)
        {
            if (string.IsNullOrEmpty(placeholderState.Format))
            {
                Replace(builder, placeholderState,  $"{position.X} {position.Y} {position.Z}".AsSpan());
                return;
            }

            StringBuilder sb = DiscordPool.Internal.GetStringBuilder();
            PlaceholderState positionState = PlaceholderState.Create(placeholderState.Data);
            sb.Append(placeholderState.Format);
            MatchCollection matches = GenericPositionRegex.Matches(placeholderState.Format);
            for (int index = matches.Count - 1; index >= 0; index--)
            {
                Match match = matches[index];
                positionState.UpdateState(match);
                switch (match.Groups[1].Value)
                {
                    case "x":
                        Replace(sb, positionState, position.X);
                        break;
                    case "y":
                        Replace(sb, positionState, position.Y);
                        break;
                    case "z":
                        Replace(sb, positionState, position.Z);
                        break;
                }
            }

            Replace(builder, placeholderState, sb.ToString());
            DiscordPool.Internal.FreeStringBuilder(sb);
            positionState.Dispose();
        }

        public static Action<StringBuilder, PlaceholderState, TResult> CreatePlaceholderCallback<TResult>()
        {
            Type type = typeof(TResult);
            if (type == typeof(string)) return (builder, state, value) => Replace(builder, state, value as string);
            if (type == typeof(bool)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, bool>());
            if (type == typeof(byte)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, byte>());
            if (type == typeof(sbyte)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, sbyte>());
            if (type == typeof(short)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, short>());
            if (type == typeof(ushort)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, ushort>());
            if (type == typeof(int)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, int>());
            if (type == typeof(uint)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, uint>());
            if (type == typeof(long)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, long>());
            if (type == typeof(ulong)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, ulong>());
            if (type == typeof(float)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, float>());
            if (type == typeof(double)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, double>());
            if (type == typeof(decimal)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, decimal>());
            if (type == typeof(DateTime)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, DateTime>());
            if (type == typeof(DateTimeOffset)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, DateTimeOffset>());
            if (type == typeof(TimeSpan)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, TimeSpan>());
            if (type == typeof(Snowflake)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, Snowflake>());
            if (type == typeof(TemplateKey)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, TemplateKey>().Name);
            if (type == typeof(GenericPosition)) return (builder, state, value) => Replace(builder, state, value.Cast<TResult, GenericPosition>());
            if (typeof(IFormattable).IsAssignableFrom(type)) return (builder, state, value) => Replace(builder, state, value as IFormattable);
            if (typeof(IReadOnlyList<string>).IsAssignableFrom(type)) return (builder, state, value) => Replace(builder, state, value as IReadOnlyList<string>);
            if (typeof(IReadOnlyList<object>).IsAssignableFrom(type)) return (builder, state, value) => Replace(builder, state, value as IReadOnlyList<object>);

            return (builder, state, value) => Replace(builder, state, value.ToString());
        }
    }
}