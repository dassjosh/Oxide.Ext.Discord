﻿using System;

namespace Oxide.Ext.Discord.Types;

internal ref struct StringTokenizer
{
    private ReadOnlySpan<char> _string;
    private readonly ReadOnlySpan<char> _token;
    private readonly int _maxLength;
    public int Index { get; private set; } = -1;

    public ReadOnlySpan<char> Current { get; private set; }

    public StringTokenizer(string str, string token) : this(str, token, str.Length) { }

    public StringTokenizer(string str, string token, int maxLength)
    {
        _string = str;
        _token = token;
        _maxLength = maxLength;
    }

    public bool MoveNext()
    {
        if (_string.Length == 0)
        {
            return false;
        }
            
        int index = _string.IndexOf(_token);
        if (index == -1 || index >= _maxLength)
        {
            index = _maxLength;
        }
            
        if (index == 0)
        {
            _string = _string.Slice(1);
            return MoveNext();
        }

        Current = _string.Slice(0, index);
        _string = _string.Slice(index + 1);
        Index++;
        return true;
    }
}